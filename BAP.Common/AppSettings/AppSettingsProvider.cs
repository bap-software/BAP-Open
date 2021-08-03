using System;
using System.Configuration;
using BAP.Common.AppSettings.SettingsTypes;

namespace BAP.Common.AppSettings
{
    /// <summary>
    /// Provides app settings from Web.config
    /// </summary>
    public static class AppSettingsProvider
    {
        public static SelfSetupStatus SetupStatus
        {
            get
            {
                var isSuccessParse = Enum.TryParse(ConfigurationManager.AppSettings[AppSettingsKey.SetupStatus], out SelfSetupStatus setupStatus);
                return isSuccessParse ? setupStatus : SelfSetupStatus.None;
            }
        }
    }
}