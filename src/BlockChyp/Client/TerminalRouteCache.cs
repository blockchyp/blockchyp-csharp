using System;
using System.Collections.Concurrent;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using BlockChyp.Entities;
using Newtonsoft.Json;

namespace BlockChyp.Client
{
    public class TerminalRouteCache
    {
        /// <summary>Prefix used for the offline cache.</summary>
        public const string DefaultOfflinePathPrefix = ".blockchyp_routes";

        private const string OfflineFixedKey = "a519bbdedf0d8ce1ae2a8d41e247effbe2e85fa6211e8203cad92307c7a843f2";

        private static ReaderWriterLockSlim fileLock = new ReaderWriterLockSlim();

        private ConcurrentDictionary<string, TerminalRouteResponse> routeCache =
            new ConcurrentDictionary<string, TerminalRouteResponse>();

        /// <summary>Gets or sets the location of the persistent terminal route cache.</summary>
        /// <value>The location of the persistent terminal route cache.</value>
        public string OfflinePathPrefix { get; set; }

        /// <summary>Gets or sets the persistent terminal route lifespan.</summary>
        /// <value>The persistent terminal route lifespan.</value>
        public TimeSpan TimeToLive { get; set; } = TimeSpan.FromMinutes(60);

        /// <summary>Enables or disables the persistent terminal route cache.</summary>
        /// <value>The state of the persistent terminal route cache.</value>
        public bool OfflineEnabled { get; set; } = true;

        /// <summary>
        /// Check the cache for a terminal route for the given root credentials.
        /// </summary>
        /// <param name="name">The name of the terminal.</param>
        /// <param name="rootCredentials">The root credentials used to establish the route.</param>
        public TerminalRouteResponse Get(string name, ApiCredentials rootCredentials)
        {
            return Get(name, rootCredentials, false);
        }

        /// <summary>
        /// Check the cache for a terminal route for the given root credentials,
        /// with the option to ignore TTL.
        /// </summary>
        /// <param name="name">The name of the terminal.</param>
        /// <param name="rootCredentials">The root credentials used to establish the route.</param>
        /// <param name="includeExpired">Whether or not to include expired routes.</param>
        public TerminalRouteResponse Get(string name, ApiCredentials rootCredentials, bool includeExpired)
        {
            var cacheKey = ToTerminalRouteKey(name, rootCredentials);

            if (routeCache.TryGetValue(cacheKey, out var route) && ValidRoute(route, includeExpired))
            {
                return route;
            }

            if (OfflineEnabled)
            {
                var offlineRoute = GetOffline(cacheKey, rootCredentials);
                if (ValidRoute(offlineRoute, includeExpired))
                {
                    routeCache[cacheKey] = offlineRoute;
                    return offlineRoute;
                }
            }

            return null;
        }

        /// <summary>
        /// Stores a terminal route for later use.
        /// </summary>
        /// <param name="route">The <see cref="TerminalRouteResponse"/> to cache.</param>
        /// <param name="rootCredentials">The root credentials used to establish the route.</param>
        public void Put(TerminalRouteResponse route, ApiCredentials rootCredentials)
        {
            var cacheKey = ToTerminalRouteKey(route.TerminalName, rootCredentials);

            routeCache[cacheKey] = route;

            if (OfflineEnabled)
            {
                var offlineRoute = (TerminalRouteResponse)route.Clone();
                offlineRoute.TransientCredentials = Encrypt(offlineRoute.TransientCredentials, rootCredentials);

                var offlineData = JsonConvert.SerializeObject(offlineRoute);
                var offlineFile = ResolveOfflineRouteCacheLocation(cacheKey);

                WriteFile(offlineFile, offlineData);
            }
        }

        private bool ValidRoute(TerminalRouteResponse route)
        {
            return ValidRoute(route, false);
        }

        private bool ValidRoute(TerminalRouteResponse route, bool includeExpired)
        {
            if (route == null || !route.Success)
            {
                return false;
            }

            return includeExpired ||
                route.Timestamp.GetValueOrDefault(new DateTime(0)).Add(TimeToLive) > DateTime.UtcNow;
        }

        private string ToTerminalRouteKey(string name, ApiCredentials rootCredentials)
        {
            return $"{rootCredentials.ApiKey}_{name}";
        }

        private string ResolveOfflineRouteCacheLocation(string key)
        {
            var snekCase = key.Replace(" ", "_");

            string prefix;
            if (string.IsNullOrEmpty(OfflinePathPrefix))
            {
                var tmp = Path.GetTempPath();
                prefix = Path.Combine(tmp, DefaultOfflinePathPrefix);
            }
            else
            {
                prefix = OfflinePathPrefix;
            }

            return $"{prefix}_{snekCase}";
        }

        private TerminalRouteResponse GetOffline(string key, ApiCredentials rootCredentials)
        {
            var cacheFile = ResolveOfflineRouteCacheLocation(key);
            if (!File.Exists(cacheFile))
            {
                return null;
            }

            string rawContent = ReadFile(cacheFile);
            try
            {
                var result = JsonConvert.DeserializeObject<TerminalRouteResponse>(rawContent);
                result.TransientCredentials = Decrypt(result.TransientCredentials, rootCredentials);

                return result;
            }
            catch (JsonException)
            {
                // File is invalid, remove it
                DeleteFile(cacheFile);
                return null;
            }
        }

        private string ReadFile(string path)
        {
            fileLock.EnterReadLock();
            try
            {
                using (var file = new StreamReader(path))
                {
                    return file.ReadToEnd();
                }
            }
            finally
            {
                fileLock.ExitReadLock();
            }
        }

        private void WriteFile(string path, string data)
        {
            fileLock.EnterWriteLock();
            try
            {
                using (var file = new StreamWriter(path))
                {
                    file.Write(data);
                }
            }
            finally
            {
                fileLock.ExitWriteLock();
            }
        }

        private void DeleteFile(string path)
        {
            fileLock.EnterWriteLock();
            try
            {
                File.Delete(path);
            }
            finally
            {
                fileLock.ExitWriteLock();
            }
        }

        private ApiCredentials Decrypt(ApiCredentials transientCredentials, ApiCredentials rootCredentials)
        {
            var key = DeriveOfflineKey(rootCredentials);

            return new ApiCredentials(
                Crypto.Decrypt(transientCredentials.ApiKey, key),
                Crypto.Decrypt(transientCredentials.BearerToken, key),
                Crypto.Decrypt(transientCredentials.SigningKey, key));
        }

        private ApiCredentials Encrypt(ApiCredentials transientCredentials, ApiCredentials rootCredentials)
        {
            var key = DeriveOfflineKey(rootCredentials);

            return new ApiCredentials(
                Crypto.Encrypt(transientCredentials.ApiKey, key),
                Crypto.Encrypt(transientCredentials.BearerToken, key),
                Crypto.Encrypt(transientCredentials.SigningKey, key));
        }

        private byte[] DeriveOfflineKey(ApiCredentials credentials)
        {
            using (var sha256 = new SHA256Managed())
            {
                var offlineKeyBytes = Crypto.FromHex(OfflineFixedKey);
                var signingKeyBytes = Crypto.FromHex(credentials.SigningKey);

                var input = new byte[offlineKeyBytes.Length + signingKeyBytes.Length];
                Buffer.BlockCopy(offlineKeyBytes, 0, input, 0, offlineKeyBytes.Length);
                Buffer.BlockCopy(signingKeyBytes, 0, input, offlineKeyBytes.Length, signingKeyBytes.Length);

                return sha256.ComputeHash(input);
            }
        }
    }
}
