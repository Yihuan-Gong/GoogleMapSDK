using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places.Requests.Models
{
    internal class AutoCompleteApiRequestModel
    {
        public AutoCompleteApiRequestModel(string input, CircleModel locationRestriction = null)
        {
            Input = input;

            if (locationRestriction != null)
            {
                LocationBias = new LocationBiasModel
                {
                    Circle = locationRestriction
                };
            }
        }

        public string Input { get; }
        public LocationBiasModel LocationBias { get; } = null;
        public string LanguageCode { get; set; } = "zh-TW";
    }

    public class LocationBiasModel
    {
        public CircleModel Circle { get; set; }
    }
}
