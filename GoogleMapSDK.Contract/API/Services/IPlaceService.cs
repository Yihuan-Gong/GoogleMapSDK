using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.API.Services
{
    public interface IPlaceService
    {
        Task<PlaceDetailModel> TextSearchAsync(string query, string languageCode = "zh-TW");
        Task<PlaceDetailModel> NearbySearchAsync(CircleModel locationRestriction, string[] includedTypes = null, int? maxResultCounts = null, string languageCode = "zh-TW");
        Task<List<PlaceSimpleModel>> AutoCompleteAsync(string input, CircleModel locationRestriction = null, string languageCode = "zh-TW");
    }
}
