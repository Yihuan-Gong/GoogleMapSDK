using GoogleMapSDK.API.Places.Models;
using GoogleMapSDK.API.Places.Requests.Models;
using HttpRequestModule;
using IoCContainer.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places.Requests
{
    [Transient]
    internal class AutoCompleteRequest : APlaceRequest<AutoCompleteApiRequestModel, PlaceAutoCompleteApiResponseModel>
    {
        public AutoCompleteRequest(HttpRequest httpRequest) : base(httpRequest)
        {
        }

        protected override Dictionary<string, string> Header => new Dictionary<string, string> 
        { 
            { 
                "X-Goog-FieldMask", 
                "suggestions.placePrediction.text,suggestions.placePrediction.placeId" 
            } 
        };

        protected override string TotalUrl => $"{BASE_URL}autocomplete";
    }
}
