using System;
using System.IO;
using BlockChyp.Client;
using BlockChyp.Entities;
using Newtonsoft.Json;
using Xunit;

namespace BlockChypTest.Client
{
    public class TerminalRouteCacheTest
    {
        [Theory]
        // Offline disabled
        [InlineData(false, false, true)]

        // Offline enabled
        [InlineData(true, false, true)]

        // Route request failed
        [InlineData(true, false, false)]

        // Route is expired
        [InlineData(true, true, true)]
        public void TerminalRouteCacheTest_RoundTrip(bool offlineEnabled, bool expired, bool successfulRoute)
        {
            using (var tmpdir = new TempDir())
            {
                var cache = GetTestRouteCache(offlineEnabled, tmpdir.Name);

                var rootCredentials = new ApiCredentials(
                    "ZDSMMZLGRPBPRTJUBTAFBYZ33Q",
                    "ZLBW5NR4U5PKD5PNP3ZP3OZS5U",
                    "9c6a5e8e763df1c9256e3d72bd7f53dfbd07312938131c75b3bfd254da787947");

                var route = new TerminalRouteResponse
                {
                    Success = successfulRoute,
                    TerminalName = "Test Terminal",
                    TransientCredentials = rootCredentials,
                    Timestamp = DateTime.UtcNow,
                };

                if (expired)
                {
                    route.Timestamp = new DateTime(0);
                }

                cache.Put(route, rootCredentials);

                if (offlineEnabled)
                {
                    // Wipe out the online cache to validate that the value is read from the offline cache.
                    cache = GetTestRouteCache(offlineEnabled, tmpdir.Name);
                }

                var result = cache.Get("Test Terminal", rootCredentials);

                string[] generatedFiles = Directory.GetFiles(tmpdir.Name, "*", SearchOption.AllDirectories);

                if (offlineEnabled && successfulRoute)
                {
                    Assert.NotEmpty(generatedFiles);

                    foreach (string filePath in generatedFiles)
                    {
                        using (var file = new StreamReader(filePath))
                        {
                            var raw = file.ReadToEnd();
                            var offlineRoute = JsonConvert.DeserializeObject<TerminalRouteResponse>(raw);

                            // Make sure the credentials exist.
                            Assert.False(String.IsNullOrEmpty(offlineRoute.TransientCredentials.ApiKey));
                            Assert.False(String.IsNullOrEmpty(offlineRoute.TransientCredentials.BearerToken));
                            Assert.False(String.IsNullOrEmpty(offlineRoute.TransientCredentials.SigningKey));

                            // Make sure the credentials are encrypted for offline storage.
                            Assert.NotEqual(rootCredentials.ApiKey, offlineRoute.TransientCredentials.ApiKey);
                            Assert.NotEqual(rootCredentials.BearerToken, offlineRoute.TransientCredentials.BearerToken);
                            Assert.NotEqual(rootCredentials.SigningKey, offlineRoute.TransientCredentials.SigningKey);
                        }
                    }
                }

                if (!offlineEnabled)
                {
                    Assert.Empty(generatedFiles);
                }

                if (expired || !successfulRoute)
                {
                    Assert.Null(result);
                }
                else
                {
                    Assert.NotNull(result);
                    Assert.Equal(route.Success, result.Success);
                    Assert.Equal(route.TransientCredentials.ApiKey, result.TransientCredentials.ApiKey);
                    Assert.Equal(route.TransientCredentials.BearerToken, result.TransientCredentials.BearerToken);
                    Assert.Equal(route.TransientCredentials.SigningKey, result.TransientCredentials.SigningKey);
                }
            }
        }

        private static TerminalRouteCache GetTestRouteCache(bool offlineEnabled, string tmpdir)
        {
            var cache = new TerminalRouteCache();
            cache.OfflineEnabled = offlineEnabled;
            cache.OfflinePathPrefix = Path.Combine(tmpdir, "RouteCacheTest");
            cache.TimeToLive = TimeSpan.FromDays(365);

            return cache;
        }
    }
}
