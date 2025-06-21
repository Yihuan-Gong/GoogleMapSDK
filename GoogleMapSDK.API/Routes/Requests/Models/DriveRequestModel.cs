using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Routes.Requests.Models
{
    public class DriveRequestModel : ARouteRequestModel
    {
        public override string TravelMode => "DRIVE";
        public string[] ExtraComputations { get; set; } = new string[] { "TOLLS" };

        /// <summary>
        /// Should be set to "TRAFFIC_AWARE" if SetDepartueTime or SetArrivalTime is given
        /// </summary>
        public string RoutingPreference { get; set; }
        public RouteModifiersModel RouteModifiers { get; set; }

        public class RouteModifiersModel
        {
            public bool AvoidTolls { get; set; }
            public bool AvoidHighways { get; set; }
            public bool AvoidFerries { get; set; }
        }
    }
}
