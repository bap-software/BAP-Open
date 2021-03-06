using BAP.Common;
using BAP.DAL;
using BAP.eCommerce.Resources;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;

namespace BAP.eCommerce.WorkflowActions
{
    public class SalesOrderEmailConfirmation : BaseCustomerOrderMailingAction
    {
        public SalesOrderEmailConfirmation(ILookupEngine lookupEngine, IFileProcessor fileProc, IConfigHelper configHelper, IAuthorizationContext context, ILogger logger) : base(lookupEngine, fileProc, configHelper, context, logger)
        {
            _emailSubject = ResObject.EmailText_OrderConfirationSubject;
        }
    }
}
