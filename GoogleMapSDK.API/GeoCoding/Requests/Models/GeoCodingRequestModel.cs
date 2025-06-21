using GoogleMapSDK.API.Common.Models;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.GeoCoding.Requests.Models
{
    public class GeoCodingRequestModel
    {
        public string PlaceId { get; set; }
        public string Address { get; set; }
        public LocationModel Latlng { get; set; }
        public string Language { get; set; } = "zh-TW";
    }
}
