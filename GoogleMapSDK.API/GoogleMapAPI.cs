using GoogleMapSDK.API.GeoCoding;
using GoogleMapSDK.API.Places;
using GoogleMapSDK.API.Routes;
using GoogleMapSDK.Contract.API;
using GoogleMapSDK.Contract.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API
{
    internal class GoogleMapAPI: IGoogleMapAPI
    {
        public IPlaceService PlaceService { get => _placeService; }
        public RouteService RouteService { get => _routeService; }
        public IGeoCodingService GeoCodingService { get => _geoCodingService; }

        private readonly IPlaceService _placeService;
        private readonly RouteService _routeService;
        private readonly IGeoCodingService _geoCodingService;

        public GoogleMapAPI(IPlaceService placeService, RouteService routeService, IGeoCodingService geoCodingService)
        {
            _placeService = placeService;
            _routeService = routeService;
            _geoCodingService = geoCodingService;
        }
    }
}
