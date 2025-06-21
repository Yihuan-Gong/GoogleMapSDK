using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Routes.Requests.Models
{
    public class PublicTransitRequestModel : ARouteRequestModel
    {
        public override string TravelMode => "TRANSIT";
        public TransitPreferencesModel TransitPreferences { get; set; }

        public class TransitPreferencesModel
        {
            public PublicTransportRoutingMode? RoutingPreference { get; set; }
            public PublicTransportMode?[] AllowedTravelModes { get; set; }

            public enum PublicTransportRoutingMode
            {
                LESS_WALKING,
                FEWER_TRANSFERS
            }

            public enum PublicTransportMode
            {
                TRAIN,
                SUBWAY,
                BUS,
                LIGHT_RAIL,
                RAIL
            }
        }
    }
}
