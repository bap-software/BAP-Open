namespace BAP.Common.Suppliers
{
    public interface IBapSupplierAction : IMustHavePublicId
    {
        SupplierExecutionResult ExecuteAction(string supplierConfig, params BapDynamicVariable[] actionArguments);
    }
}