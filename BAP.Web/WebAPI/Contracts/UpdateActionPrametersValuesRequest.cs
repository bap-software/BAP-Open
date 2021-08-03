namespace BAP.Web.WebAPI.Contracts
{
    public class UpdateActionPrametersValuesRequest
    {
        public int NodeId { get; set; }
        public string ActionParametersJson { get; set; }
    }
}