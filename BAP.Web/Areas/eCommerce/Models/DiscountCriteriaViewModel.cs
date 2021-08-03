using BAP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAP.Web.Areas.eCommerce.Models
{    
    public class DiscountCriteriaViewModel
    {
        public string Id { get; set; }
        public CriteriaFieldType FieldType { get; set; }
        public CriteriaFieldDataType DataType { get; set; }        
        public string FieldName { get; set; }
        public string FieldCaption { get; set; }
        public int Level { get; set; }
        public List<CriteriaCompareOperator> AllowedOperators { get; set; }
        public CriteriaCompareOperator Operator { get; set; }
        public List<string> Values { get; set; }
        public List<LookupItem> ObjectLookup { get; set; }
    }
}