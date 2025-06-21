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
    internal class TextSearchRequest : APlaceRequest<TextSearchApiRequestModel, PlaceDetailApiResponseModel>
    {
        public TextSearchRequest(HttpRequest httpRequest) : base(httpRequest)
        {
        }

        protected override Dictionary<string, string> Header
            => new Dictionary<string, string> { { "X-Goog-FieldMask", "*" } };

        protected override string TotalUrl => $"{BASE_URL}searchText";
    }
}
