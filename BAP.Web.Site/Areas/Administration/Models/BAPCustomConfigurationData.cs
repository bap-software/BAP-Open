using BAP.BL.CustomConfigurationNodes;

namespace BAP.Web.Areas.Administration.Models
{
    public class BAPCustomConfigurationData
    {
        public CustomConfigurationNode RootNode { get; set; }
        public CustomConfigurationNode CurrentNode { get; set; }
        public string CurrentTab { get; set; }
    }
}