namespace BAP.Web.WebAPI.Contracts
{
    public class UpdateNodeContentRequest
    {
        public RequestSourceApp SourceApp { get; set; }
        public int NodeId { get; set; }
        public string ContentHtml { get; set; }
    }
}