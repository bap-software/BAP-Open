using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using BAP.Common.AppSettings;
using BAP.Common.AppSettings.SettingsTypes;
using BAP.SelfSetup.Db;
using BAP.SelfSetup.Models;

namespace BAP.SelfSetup.Controllers
{
    public class BapInstallerController : Controller
    {
        // TODO: Try to change this later to use Pre-build event of this project to move this view to appreciate folder of WEB application.
        // This is required to be able use Views from different projects.
        private const string InitAppViewPath = "/BAPSelfSetupContent/Views/BapInstaller/InitApplication.cshtml";
        private const string UpdateDefaultDataViewPath = "/BAPSelfSetupContent/Views/BapInstaller/UpdateDefaultData.cshtml";
        private const string DeleteAllTablesSqlPath = "/BAPSelfSetupContent/Scripts/delete-all-tables.sql";
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult InitApplication()
        {
            var model = new DbConnectionConfig
            {
                DbConnectionName = BapInstaller.Config.DbConnectionName
            };
            var viewPath = ViewPath(InitAppViewPath);
            
            return View(viewPath, model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SetupDatabase(DbConnectionConfig model)
        {
            AppSettingsEditor.SetConnectionString(model.DbConnectionName, model.DbConnectionString);
            
            CreateEmptyDb(model);
            
            AppSettingsEditor.SetSetupStatus(SelfSetupStatus.InProgress);
            
            return RedirectToAction(nameof(UpdateDefaultData));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult UpdateDefaultData()
        {
            var model = new OrganizationConfig();
            var viewPath = ViewPath(UpdateDefaultDataViewPath);
            return View(viewPath, model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult UpdateDefaultData(OrganizationConfig model)
        {
            EnsureDbIsEmpty();
            RunMigrationsOnDb();
            UpdateDefaultOrganization(model, BapInstaller.Config.DbConnectionName);
            
            AppSettingsEditor.SetSetupStatus(SelfSetupStatus.Finish);
            
            return Redirect("/");
        }

        private static void RunMigrationsOnDb()
        {
            var configuration = BapInstaller.Config.DbMigrationConfigProvider?.Invoke();

            if (configuration == null)
            {
                return;
            }
            
            configuration.ContextType = BapInstaller.Config.DbContextType;

            var migrator = new DbMigrator(configuration);
            
            try
            {
                migrator.Update();
            }
            catch
            {
                // ignore
            }
        }

        private static void CreateEmptyDb(DbConnectionConfig model)
        {
            using (var context = new DbContext(model.DbConnectionString))
            {
                context.Database.CreateIfNotExists();
            }
        }
        
        private void EnsureDbIsEmpty()
        {
            var dbContext = BapInstaller.Config.DbProvider?.Invoke();

            if (dbContext == null)
            {
                return;
            }

            var deleteAllTablesFullPath = FullPath(DeleteAllTablesSqlPath);

            if (!System.IO.File.Exists(deleteAllTablesFullPath))
            {
                return;
            }

            using (dbContext)
            {
                var sqlCommand = System.IO.File.ReadAllText(deleteAllTablesFullPath);
                
                dbContext.Database.ExecuteSqlCommand(sqlCommand);
            }
        }

        /// <summary>
        /// Try match all props between InstallationModel and Organization.
        /// </summary>
        private static void UpdateDefaultOrganization(OrganizationConfig model, string connectionStringName)
        {
            using (var dbContext = new SetupDbContext(connectionStringName))
            {
                var defOrganization = dbContext.Organizations.FirstOrDefault();

                if (defOrganization == null)
                {
                    return;
                }

                MapModelToOrganization(model, defOrganization);

                dbContext.SaveChanges();
            }
        }

        private static void MapModelToOrganization(OrganizationConfig model, SetupOrganization defOrganization)
        {
            var orgProps = typeof(SetupOrganization).GetProperties().ToDictionary(x => x.Name);
            var modelProps = model.GetType().GetProperties().ToDictionary(x => x.Name);

            foreach (var modelProp in modelProps)
            {
                var modelValue = modelProp.Value.GetValue(model);

                if (string.IsNullOrEmpty(modelValue?.ToString()))
                {
                    continue;
                }

                var orgProp = orgProps[modelProp.Key];

                orgProp.SetValue(defOrganization, modelValue);
            }
        }

        private string FullPath(string filePath)
        {
            var rootDirectory = BapInstaller.Config.ContentRootPath.Trim('/').Trim('\\');
            var trimFilePath = filePath.Trim('/').Trim('\\');
            
            return Server.MapPath($"~/{rootDirectory}/{trimFilePath}");
        }
        
        private string ViewPath(string filePath)
        {
            var rootDirectory = BapInstaller.Config.ContentRootPath.Trim('/').Trim('\\');
            var trimFilePath = filePath.Trim('/').Trim('\\');
            
            return $"/{rootDirectory}/{trimFilePath}";
        }
    }
}