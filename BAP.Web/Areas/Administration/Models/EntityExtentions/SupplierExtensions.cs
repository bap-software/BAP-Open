using System.Collections.Generic;
using BAP.eCommerce.DAL.Entities;

namespace BAP.Web.Areas.Administration.Models.EntityExtentions
{
    public static class ModelBind
    {
        public static class Supplier
        {
            public const string Create = "Name,ShortDescription,Description,Config,SupplierActionClassesDbValue,SupplierActionAssembly";
            public const string Edit = "Id,Name,ShortDescription,Description,Config,SupplierActionClassesDbValue,SupplierActionAssembly,TenantUnit,TenantUnitId,CreateDate,CreatedBy,LastModifiedDate,TimeStamp,LastModifiedBy,CreatedByUserName,LastModifiedByUserName,OwnerGroup,OwnerPermissions,CultureCode,LocalizationId";
        }
    }
}