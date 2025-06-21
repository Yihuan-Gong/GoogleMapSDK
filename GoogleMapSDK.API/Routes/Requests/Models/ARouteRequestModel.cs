using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Routes.Requests.Models
{
    public abstract class ARouteRequestModel
    {
        public PlaceModel Origin { get; set; }
        public PlaceModel Destination { get; set; }
        public PlaceModel[] Intermediates { get; set; }
        public bool ComputeAlternativeRoutes { get; set; } = false;
        public string LanguageCode { get; set; } = "zh-TW";
        public string Units { get; set; } = "METRIC";
        public string DepartureTime { get => _departureTime?.ToString(TIME_FORMAT); }
        public string ArrivalTime { get => _arrivalTime?.ToString(TIME_FORMAT); }

        /// <summary>
        /// SetDepartureTime and SetArrivalTime can only be eighter used.
        /// </summary>
        public DateTime? SetDepartureTime { set => _departureTime = value; }

        /// <summary>
        /// SetDepartureTime and SetArrivalTime can only be eighter used.
        /// </summary>
        public DateTime? SetArrivalTime { set => _arrivalTime = value; }

        private DateTime? _departureTime;
        private DateTime? _arrivalTime;


        private const string TIME_FORMAT = "yyyy-MM-ddThh:mm:ssZ";
        public abstract string TravelMode { get; }

        public class PlaceModel
        {
            public string PlaceId { get; set; }
        }
    }
}
