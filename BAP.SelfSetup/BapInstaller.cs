using System;
using BAP.SelfSetup.Models;

namespace BAP.SelfSetup
{
    public static class BapInstaller
    {
        public static InstallerConfig Config { get; private set; } = new InstallerConfig();
        
        public static string ControllerNamespace => typeof(BapInstaller).Namespace;

        public static void Setup(Action<InstallerConfig> setup)
        {
            setup?.Invoke(Config);
        }
    }
}