using System;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using BlockChyp.Client;
using BlockChyp.Entities;

namespace BlockChypTest
{
    public class IntegrationTestConfiguration
    {
        private IntegrationTestConfiguration()
        {
            string configFilePath = ConfigFilePath();
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"No integration test config file: {configFilePath}", configFilePath);
            }

            string data = File.ReadAllText(configFilePath);

            Settings = JsonConvert.DeserializeObject<IntegrationTestSettings>(data);
        }

        public IntegrationTestSettings Settings { get; }

        public BlockChypClient GetTestClient()
        {
            return new BlockChypClient(
                Settings.GatewayUrl,
                Settings.GatewayTestUrl,
                new ApiCredentials(Settings.ApiKey, Settings.BearerToken, Settings.SigningKey));
        }

        public static string ConfigFilePath()
        {
            string osConfigDir;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                osConfigDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            } else {
                osConfigDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }

            return Path.Combine(osConfigDir, ConfigDir, ConfigFile);
        }

        public static IntegrationTestConfiguration Instance = new IntegrationTestConfiguration();

        private class Singleton
        {
            static Singleton()
            {
            }

            internal static readonly IntegrationTestConfiguration instance = new IntegrationTestConfiguration();
        }

        public const string ConfigFile = "sdk-itest-config.json";
        public const string ConfigDir = "sdk-itest";
    }
}
