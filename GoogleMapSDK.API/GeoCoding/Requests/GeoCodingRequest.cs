using GoogleMapSDK.API.Common.Abstracts;
using GoogleMapSDK.API.GeoCoding.JsonConverters;
using GoogleMapSDK.API.GeoCoding.Requests.Models;
using GoogleMapSDK.API.GeoCoding.Responses;
using HttpRequestModule;
using IoCContainer.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.GeoCoding.Requests
{
    [Transient]
    internal class GeoCodingRequest : AGetRequest<GeoCodingRequestModel, GeoCodingResponseModel>
    {
        public GeoCodingRequest(HttpRequest httpRequest) : base(httpRequest)
        {
        }

        protected override string TotalUrl => "https://maps.googleapis.com/maps/api/geocode/json";

        protected override JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new LocationModelConverter()
            },
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };
    }
}
