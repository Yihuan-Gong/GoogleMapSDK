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
        Task<PlaceDetailModel> TextSearchAsync(string query);
        Task<PlaceDetailModel> NearbySearchAsync(CircleModel locationRestriction, string[] includedTypes = null, int? maxResultCounts = null);
        Task<List<PlaceSimpleModel>> AutoCompleteAsync(string input, CircleModel locationRestriction = null);
    }
}
