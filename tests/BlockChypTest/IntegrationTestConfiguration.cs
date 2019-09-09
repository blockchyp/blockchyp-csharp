using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using BlockChyp;
using BlockChyp.Client;

namespace BlockChypTest
{
    public class IntegrationTestConfiguration
    {
        private IntegrationTestConfiguration()
        {
            var configFilePath = ConfigFilePath();
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"No integration test config file: {configFilePath}", configFilePath);
            }

            var data = File.ReadAllText(configFilePath);

            Settings = JsonSerializer.Deserialize<IntegrationTestSettings>(data);
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