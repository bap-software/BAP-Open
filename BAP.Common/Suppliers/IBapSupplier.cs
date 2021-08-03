using System.Collections.Generic;

namespace BAP.Common.Suppliers
{
    public interface IBapSupplier
    {
        string ExecutionConfig { get; set; }
        
        List<string> SupplierActionClasses { get; set; }
        string SupplierActionAssembly { get; set; }
    }
}