using System;
using System.Linq;
using System.Configuration;

using Microsoft.Owin;
using Owin;

using Hangfire;
using Hangfire.SqlServer;
using Hangfire.Dashboard;

using BAP.BL.Tasks;
using System.Collections.Generic;

namespace BAP.Web
{
    public partial class Startup
    {
        private IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(ConfigurationManager.ConnectionStrings["HangFireConnection"].ConnectionString, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                });

            yield return new BackgroundJobServer();
        }

        public void ConfigureHangFire(IAppBuilder app)
        {
            app.UseHangfireAspNet(GetHangfireServers);            
            app.UseHangfireDashboard("/Hangfire", new DashboardOptions { AppPath = "/Administration/ScheduledTasks", Authorization = new[] { new HFAuthorizationFilter() } });

            var taskEngine = new TaskEngine();
            var tasks = taskEngine.GetAllFutureTasks();
            if(tasks != null && tasks.Any())
                tasks.ToList().ForEach(x => taskEngine.AddTask(x));
        }
    }

    public class HFAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // In case you need an OWIN context, use the next line, `OwinContext` class
            // is the part of the `Microsoft.Owin` package.
            var owinContext = new OwinContext(context.GetOwinEnvironment());

            // Allow all authenticated users to see the Dashboard (potentially dangerous).
            return owinContext.Authentication.User.Identity.IsAuthenticated;
        }
    }
}