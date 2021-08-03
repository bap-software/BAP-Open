using BAP.ContentManagement;
using BAP.ContentManagement.DesignComponents;

namespace BAP.Web.Areas.Administration.Models
{
    public class BAPContentManagementData
    {
        public CMSNode RootNode { get; set; }
        public CMSNode CurrentNode { get; set; }
        public int? CurrentViewId { get; set; }
        public string CurrentViewContent { get; set; }
        public string CurrentTab { get; set; }
        public DesignComponentsCollection DesignComponets { get; set; }
    }
}