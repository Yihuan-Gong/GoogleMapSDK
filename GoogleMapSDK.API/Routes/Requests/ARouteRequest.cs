using GoogleMapSDK.API.Common.Abstracts;
using GoogleMapSDK.API.Routes.Models;
using GoogleMapSDK.API.Routes.Requests.Models;
using HttpRequestModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Routes.Requests
{
    internal abstract class ARouteRequest<TRequestModel, TResponseModel> :
        APostRequest<TRequestModel, TResponseModel>
        where TRequestModel : ARouteRequestModel
        where TResponseModel : RouteResponseModel
    {
        protected ARouteRequest(HttpRequest httpRequest) : base(httpRequest)
        {
        }

        protected override PropertyMode BodyFormat => PropertyMode.CamelCase;

        protected override Dictionary<string, string> Header
            => new Dictionary<string, string> { { "X-Goog-FieldMask", "*" } };

        protected override string TotalUrl => "https://routes.googleapis.com/directions/v2:computeRoutes";
    }
}
