namespace BAP.Web.WebAPI.Contracts
{
    public class UpdateNodeSettingsRequest
    {
        public int nodeId { get; set; }
        public int viewId { get; set; }
        public string pageTab { get; set; }
        public string designGroup { get; set; }
        public string settingsPane { get; set; }
        public string controlUsed { get; set; }
        public bool? showDesignPane { get; set; }
    }
}