using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BAP.Web.Startup))]
namespace BAP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
