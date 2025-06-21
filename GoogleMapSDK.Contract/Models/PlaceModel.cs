using GoogleMapSDK.Contract.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models
{
    public class PlaceModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string FormattedAddress { get; set; }
        public LocationModel Location { get; set; }

        private readonly IGoogleMapAPI _api;

        public PlaceModel(IGoogleMapAPI googleMapAPI)
        {
            _api = googleMapAPI;
        }

        //public Task<PlaceDetailModel> GetPlaceDetail()
        //{

        //}
    }
}
