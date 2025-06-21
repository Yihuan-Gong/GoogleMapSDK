using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.API.Services
{
    public interface IGeoCodingService
    {
        Task<List<PlaceModel>> GetPlacesByAddress(string address);
        Task<PlaceModel> GetPlaceById(string placeId);
        Task<List<PlaceModel>> GetPlacesByLocation(LocationModel location);


    }
}
