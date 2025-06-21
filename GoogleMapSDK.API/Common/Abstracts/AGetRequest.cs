using HttpRequestModule;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Common.Abstracts
{
    public abstract class AGetRequest<TRequestModel, TResponseModel> : ARequest<TRequestModel, TResponseModel>
    {
        public AGetRequest(HttpRequest httpRequest) : base(httpRequest)
        {
        }

        public override async Task<TResponseModel> SendRequestAsync()
        {
            string urlParmJson = JsonConvert.SerializeObject(RequestData, JsonSerializerSettings);
            Dictionary<string, string> urlParmDict = JsonToDictionary(urlParmJson);
            urlParmDict.Add("key", ConfigurationManager.AppSettings["apiKey"]);
            
            string jsonResult = await httpRequest.GetAsync(TotalUrl, urlParmDict);
            return DeserializeResponse(jsonResult);
        }

        private Dictionary<string, string> JsonToDictionary(string json)
        {
            var dict = new Dictionary<string, string>();
            var jObject = JObject.Parse(json);

            foreach (var property in jObject.Properties())
            {
                if (property.Value.Type != JTokenType.Null)
                {
                    dict[property.Name] = property.Value.ToString();
                }
            }

            return dict;
        }
    }
}
