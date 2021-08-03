using Newtonsoft.Json;

namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    public interface IResponseWithError
    {
        int ErrorCode { get; set; }
        
        string ErrorMessage { get; set; }
    }
}