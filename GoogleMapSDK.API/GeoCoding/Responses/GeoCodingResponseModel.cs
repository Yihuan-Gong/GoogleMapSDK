using GoogleMapSDK.API.Common.Abstracts;
using GoogleMapSDK.API.Common.Models;
using GoogleMapSDK.Contract.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.GeoCoding.Responses
{
    internal class GeoCodingResponseModel : AResponseModelV1
    {
        public GeoCodingModel[] Results { get; set; }

        public List<PlaceModel> GetPlaces()
        {
            CheckStatusOrThrowException();

            return Results.Select(x => new PlaceModel(GoogleMapAPI)
            {
                Id = x.PlaceId,
                FormattedAddress = x.FormattedAddress,
                Location = x.Geometry?.Location,
            }).ToList();
        }
    }

    public class GeoCodingModel
    {
        public string PlaceId { get; set; }

        public string FormattedAddress { get; set; }

        public GeometryModel Geometry { get; set; }

        public List<NavigationPointModel> NavigationPoints { get; set; }
    }

    public class GeometryModel
    {
        public LocationModel Location { get; set; }

        public Bounds Bounds { get; set; }
    }

    public class Bounds
    {
        public LocationModel Northeast { get; set; }

        public LocationModel Southwest { get; set; }
    }

    public class NavigationPointModel
    {
        public LocationModel Location { get; set; }

        public List<string> RestrictedTravelModes { get; set; }
    }

}
