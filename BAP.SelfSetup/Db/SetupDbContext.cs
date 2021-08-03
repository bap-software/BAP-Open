using System.Data.Entity;

namespace BAP.SelfSetup.Db
{
    /// <summary>
    /// Copy of DB context.
    /// Uses to work only with data without any additional attributes that could don't allow work with data.
    /// </summary>
    public class SetupDbContext : DbContext
    {
        public SetupDbContext(string connectionName) : base($"name={connectionName}")
        { }
        
        public DbSet<SetupOrganization> Organizations { get; set; }
    }
}