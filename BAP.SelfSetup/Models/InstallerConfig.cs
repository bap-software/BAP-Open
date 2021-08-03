using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace BAP.SelfSetup.Models
{
    public class InstallerConfig
    {
        public Func<DbContext> DbProvider { get; set; }
        public Func<DbMigrationsConfiguration> DbMigrationConfigProvider { get; set; }
        public Type DbContextType { get; set; }
        public string DbConnectionName { get; set; }
        public string ContentRootPath { get; set; } = "~";
    }
}