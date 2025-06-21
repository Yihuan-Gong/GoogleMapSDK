using GoogleMapSDK.API.Common.Abstracts;
using GoogleMapSDK.API.GeoCoding.Requests;
using GoogleMapSDK.API.GeoCoding.Requests.Models;
using GoogleMapSDK.API.GeoCoding.Responses;
using GoogleMapSDK.Contract.API.Services;
using GoogleMapSDK.Contract.Models;
using IoCContainer.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.GeoCoding
{
    [Transient]
    internal class GeoCodingService : AService, IGeoCodingService
    {
        public GeoCodingService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<List<PlaceModel>> GetPlacesByAddress(string address)
        {
            var apiRequestData = new GeoCodingRequestModel
            {
                Address = address
            };
            var result = await GetGeoCoding(apiRequestData);
            return result.GetPlaces();
        }

        public async Task<PlaceModel> GetPlaceById(string placeId)
        {
            var apiRequestData = new GeoCodingRequestModel
            {
                PlaceId = placeId
            };
            var result = await GetGeoCoding(apiRequestData);
            return result.GetPlaces().FirstOrDefault();
        }

        public async Task<List<PlaceModel>> GetPlacesByLocation(LocationModel location)
        {
            var apiRequestData = new GeoCodingRequestModel
            {
                Latlng = location
            };
            var result = await GetGeoCoding(apiRequestData);
            return result.GetPlaces();
        }

        private async Task<GeoCodingResponseModel> GetGeoCoding(GeoCodingRequestModel requestData)
        {
            return await SendRequestAsync<GeoCodingRequest, GeoCodingRequestModel, GeoCodingResponseModel>(requestData);
        }
    }
}
