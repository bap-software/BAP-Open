using System.Configuration;
using System.Linq;
using System.Web.Configuration;
using BAP.Common.AppSettings.SettingsTypes;

namespace BAP.Common.AppSettings
{
    public static class AppSettingsEditor
    {
        public static void SetSetupStatus(SelfSetupStatus status, string webConfigPath = "~")
        {
            var config = WebConfigurationManager.OpenWebConfiguration(webConfigPath);
            var appSettings = config.AppSettings.Settings
                .Cast<KeyValueConfigurationElement>()
                .ToDictionary(x => x.Key);

            if (appSettings.ContainsKey(AppSettingsKey.SetupStatus))
            {
                appSettings[AppSettingsKey.SetupStatus].Value = status.ToString();
            }
            else
            {
                config.AppSettings.Settings.Add(new KeyValueConfigurationElement(AppSettingsKey.SetupStatus, status.ToString()));
            }
            
            config.Save(ConfigurationSaveMode.Modified);
        }

        public static void SetConnectionString(string connectionName, string connectionString, string webConfigPath = "~", string connectionStringsSection = "connectionStrings")
        {
            const string sqlProvider = "System.Data.SqlClient";


            var config = WebConfigurationManager.OpenWebConfiguration(webConfigPath);

            var connectionSection = (ConnectionStringsSection) config.GetSection(connectionStringsSection);
            
            var connectionStrings = connectionSection.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .ToDictionary(x => x.Name);

            if (connectionStrings.ContainsKey(connectionName))
            {
                var connectionStringValue = connectionStrings[connectionName];
                connectionStringValue.ConnectionString = connectionString;
            }
            else
            {
                connectionSection.ConnectionStrings.Add(new ConnectionStringSettings(connectionName, connectionString, sqlProvider));
            }
            
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}