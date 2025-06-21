using GoogleMapSDK.API.Common.Abstracts;
using GoogleMapSDK.API.Places.Models;
using HttpRequestModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places.Requests
{
    internal abstract class APlaceRequest<TRequestModel, TResponseModel> : 
        APostRequest<TRequestModel, TResponseModel>
        where TRequestModel : class
        where TResponseModel : AResponseModelV2
    {
        protected APlaceRequest(HttpRequest httpRequest) : base(httpRequest)
        {
        }

        protected const string BASE_URL = "https://places.googleapis.com/v1/places:";
        protected override PropertyMode BodyFormat => PropertyMode.CamelCase;
    }
}
