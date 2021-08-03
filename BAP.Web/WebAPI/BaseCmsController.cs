using System.Web.Http;
using System.Collections.Generic;
using System.Reflection;

using BAP.BL;
using BAP.DAL;
using BAP.Log;
using BAP.Lookups;
using BAP.Common;
using BAP.FileSystem;

namespace BAP.Web.WebAPI
{
    public class BaseCmsController : ApiController
    {
        protected readonly BusinessLayer _bl = null;
        protected readonly IFileProcessor _fileProcessor = null;
        protected readonly ILogger _logger;
        protected readonly IConfigHelper _configHelper;
        protected readonly IAuthorizationContext _context;

        public BaseCmsController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context) : base()
        {
            _logger = logger;
            _fileProcessor = fileProc;
            _configHelper = configHelper;
            _context = context;
            _bl = new BusinessLayer(configHelper, context, lookupEngine, logger);
        }

        protected List<Assembly> GetAssembliesToScan()
        {
            var assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetExecutingAssembly());
            assemblies.AddRange(BAP.UI.PluginAreaBootstrapper.PluginAssemblies);
            return assemblies;
        }

    }
}
