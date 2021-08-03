using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BAP.Common.AppSettings;
using BAP.Common.AppSettings.SettingsTypes;
using BAP.DAL.Entities;
using BAP.SelfSetup.Controllers;

namespace BAP.SelfSetup
{
    public static class InitialSetupValidator
    {
        private static readonly string InitRequestController = nameof(BapInstallerController).Replace("Controller", "");
        private static readonly string InitRequestPath = $"/{InitRequestController}/{nameof(BapInstallerController.InitApplication)}";
        private static readonly string UpdateDataPath = $"/{InitRequestController}/{nameof(BapInstallerController.UpdateDefaultData)}";
        
        public static void RedirectToInitialization(HttpContext filterContext)
        {
            if (filterContext.Request.Path.Contains(InitRequestController) || AppSettingsProvider.SetupStatus == SelfSetupStatus.Finish)
            {
                return;
            }
            
            if (AppSettingsProvider.SetupStatus == SelfSetupStatus.InProgress)
            {
                filterContext.Response.Redirect(UpdateDataPath);
                return;
            }
            
            var shouldSetup = false;
            
            var context = BapInstaller.Config.DbProvider?.Invoke();

            var validations = new List<Func<bool>>
            {
                () => context == null,
                () => string.IsNullOrEmpty(context?.Database.Connection?.ConnectionString),
                () =>
                {
                    // Explicitly check connection to DB if it is correct
                    try
                    {
                        using (var sqlConn = new SqlConnection(context?.Database.Connection?.ConnectionString ?? string.Empty))
                        {
                            sqlConn.Open();
                        }
                    }
                    catch
                    {
                        return true;
                    }

                    return false;
                },
                () => context != null && !context.Database.Exists(),
                () => context != null && !context.Set<Organization>().Any(),
            };
            
            try
            {
                shouldSetup = validations.Any(validate => validate());
            }
            catch
            {
                shouldSetup = true;
            }

            var isInitialRun = AppSettingsProvider.SetupStatus == SelfSetupStatus.None ||
                               AppSettingsProvider.SetupStatus == SelfSetupStatus.Init;
            
            if (shouldSetup && isInitialRun)
            {
                filterContext.Response.Redirect(InitRequestPath);
            }
        }
    }
}