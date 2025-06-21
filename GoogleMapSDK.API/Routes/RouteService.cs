using GoogleMapSDK.API.Common.Abstracts;
using GoogleMapSDK.API.Routes.Models;
using GoogleMapSDK.API.Routes.Requests;
using GoogleMapSDK.API.Routes.Requests.Models;
using IoCContainer.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.API.Routes.Requests.Models.ARouteRequestModel;

namespace GoogleMapSDK.API.Routes
{
    [Transient]
    internal class RouteService : AService
    {
        public RouteService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<RouteResponseModel> CreateDriveRoute(string startPlaceId, string destPlaceId)
        {
            var requestData = new DriveRequestModel
            {
                Origin = new PlaceModel() { PlaceId = startPlaceId },
                Destination = new PlaceModel() { PlaceId = destPlaceId }
            };

            return await SendRequestAsync<DriveRequest, DriveRequestModel, RouteResponseModel>(requestData);
        }

        public async Task<RouteResponseModel> CreateDriveRoute(DriveRequestModel requestData)
        {
            return await SendRequestAsync<DriveRequest, DriveRequestModel, RouteResponseModel>(requestData);
        }

        public async Task<RouteResponseModel> CreatePublicTransitRoute(PublicTransitRequestModel requestModel)
        {
            return await SendRequestAsync<PublicTransitRequest, PublicTransitRequestModel, RouteResponseModel>(requestModel);
        }

        public async Task<RouteResponseModel> CreateWalkRoute(WalkRequestModel requestModel)
        {
            return await SendRequestAsync<WalkRequest, WalkRequestModel, RouteResponseModel>(requestModel);
        }
    }
}
