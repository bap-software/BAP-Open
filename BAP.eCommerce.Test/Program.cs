using System;
using System.Configuration;
using System.Text;
using BAP.Common;
using BAP.eCommerce.NovaPoshtaShippingProvider;
using RestSharp;

namespace BAP.eCommerce.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiUrl = ConfigurationManager.AppSettings["BAP.Common.NovaPoshta.UrlJson"];
            var apiKey = ConfigurationManager.AppSettings["BAP.Common.NovaPoshta.ApiKey"];

            var client = new RestClient(apiUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");

            RootObject root = new RootObject();
            root.apiKey = apiKey;
            root.modelName = "InternetDocument";
            root.calledMethod = "getDocumentPrice";
            root.methodProperties = new MethodProperties();
            root.methodProperties.CitySender = "8d5a980d-391c-11dd-90d9-001a92567626";
            root.methodProperties.CityRecipient = "db5c88e0-391c-11dd-90d9-001a92567626";
            root.methodProperties.Weight = 15;
            root.methodProperties.ServiceType = "DoorsDoors";
            root.methodProperties.Cost = 100;
            root.methodProperties.CargoType = "Cargo";
            root.methodProperties.SeatsAmount = 1;
            root.methodProperties.PackCalculate = new PackCalculate();
            root.methodProperties.PackCalculate.PackCount = 1;
            root.methodProperties.PackCalculate.PackRef = "1499fa4a-d26e-11e1-95e4-0026b97ed48a";
            root.methodProperties.RedeliveryCalculate = new RedeliveryCalculate();
            root.methodProperties.RedeliveryCalculate.CargoType = "Money";
            root.methodProperties.RedeliveryCalculate.Amount = 1;

            request.AddParameter("application/xml", JSONHelper.ToJSON(root), ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var resp = JSONHelper.FromJSON<GetDocumentPriceResponse>(response.Content);
            Console.WriteLine(response.Content);
            Console.ReadLine();
        }
    }
}
