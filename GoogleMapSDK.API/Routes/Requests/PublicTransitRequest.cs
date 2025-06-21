using GoogleMapSDK.API.Routes.Models;
using GoogleMapSDK.API.Routes.Requests.Models;
using HttpRequestModule;
using IoCContainer.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Routes.Requests
{
    [Transient]
    internal class PublicTransitRequest : ARouteRequest<PublicTransitRequestModel, RouteResponseModel>
    {
        public PublicTransitRequest(HttpRequest httpRequest) : base(httpRequest)
        {
        }
    }
}
