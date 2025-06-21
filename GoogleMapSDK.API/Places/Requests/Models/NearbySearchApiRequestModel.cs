using GoogleMapSDK.API.Places.Models;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places.Requests.Models
{
    internal class NearbySearchApiRequestModel
    {
        public NearbySearchApiRequestModel(CircleModel locationRestriction)
        {
            LocationRestriction = locationRestriction;
        }

        public CircleModel LocationRestriction { get; }
        public string[] IncludedTypes { get; set; } = null;
        public int? MaxResultCounts { get; set; } = null;
        public string LanguageCode { get; set; } = "zh-TW";
    }
}
