namespace BAP.Web.WebAPI.Contracts
{
    public class GetActionPrametersValuesResponse : BasicResponse
    {
        public int ContentNodeId { get; set; }
        public string ParametersValuesJson { get; set; }
    }
}