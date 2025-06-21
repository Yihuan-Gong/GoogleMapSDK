using GoogleMapSDK.Contract.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models
{
    public class PlaceSimpleModel
    {
        public string Name { set; get; }
        public string Id { set; get; }

        private readonly IGoogleMapAPI _api;

        public PlaceSimpleModel(IGoogleMapAPI googleMapAPI)
        {
            _api = googleMapAPI;
        }

        public async Task<PlaceModel> GetPlaceAsync()
        {
            var result = await _api.GeoCodingService.GetPlaceById(Id);
            result.Name = Name;
            return result;
        }
    }
}
