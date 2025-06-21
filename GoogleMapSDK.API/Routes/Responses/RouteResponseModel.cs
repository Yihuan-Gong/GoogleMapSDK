using GoogleMapSDK.API.Common.Abstracts;
using GoogleMapSDK.API.Common.Models;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Routes.Models
{
    public class RouteResponseModel : AResponseModelV2
    {
        public RouteModel[] Routes { get; set; }

        public class RouteModel
        {
            public LegModel[] Legs { get; set; }
            public int DistanceMeters { get; set; }
            public string Duration { get; set; }
            public string StaticDuration { get; set; }
            public PolylineModel Polyline { get; set; }
            public string Description { get; set; }
            //public ViewportModel Viewport { get; set; }
            public TravelAdvisoryModel TravelAdvisory { get; set; }
            //public string RouteToken { get; set; }
            //public string[] RouteLabels { get; set; }
        }

        public class LegModel
        {
            public int DistanceMeters { get; set; }
            public string Duration { get; set; }
            //public string StaticDuration { get; set; }
            public PolylineModel Polyline { get; set; }
            public RouteLocationModel StartLocation { get; set; }
            public RouteLocationModel EndLocation { get; set; }
            public StepModel[] Steps { get; set; }
        }

        public class StepModel
        {
            public int DistanceMeters { get; set; }
            public string StaticDuration { get; set; }
            public PolylineModel Polyline { get; set; }
            public RouteLocationModel StartLocation { get; set; }
            public RouteLocationModel EndLocation { get; set; }
            public NavigationInstructionModel NavigationInstruction { get; set; }
            public string TravelMode { get; set; }
        }

        public class NavigationInstructionModel
        {
            public string Maneuver { get; set; }
            public string Instructions { get; set; }
        }

        public class RouteLocationModel
        {
            public LocationModel LatLng { get; set; }
        }

        public class PolylineModel
        {
            public string EncodedPolyline { get; set; }
        }

        public class TravelAdvisoryModel
        {
            public MoneyModel TransitFare { get; set; }

            public TollInfoModel TollInfo { get; set; }
        }

        public class TollInfoModel
        {
            public MoneyModel[] EstimatedPrice { get; set; }
        }

        public class MoneyModel
        {
            public string CurrencyCode { get; set; }
            public string Units { get; set; }
        }
    }
}
