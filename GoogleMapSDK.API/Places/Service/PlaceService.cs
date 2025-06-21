using GoogleMapSDK.API.Common.Abstracts;
using GoogleMapSDK.API.Places.Models;
using GoogleMapSDK.API.Places.Requests;
using GoogleMapSDK.API.Places.Requests.Models;
using GoogleMapSDK.Contract.Models;
using DTO;
using IoCContainer.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using GoogleMapSDK.Contract.API.Services;

namespace GoogleMapSDK.API.Places
{
    [Transient]
    internal class PlaceService : AService, IPlaceService
    {
        public PlaceService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<PlaceDetailModel> TextSearchAsync(string query)
        {
            var result = await SendRequestAsync<TextSearchRequest, TextSearchApiRequestModel, PlaceDetailApiResponseModel>(new TextSearchApiRequestModel
            {
                Query = query
            });
            return result.GetPlaceDetail();
        }

        public async Task<PlaceDetailModel> NearbySearchAsync(CircleModel locationRestriction, string[] includedTypes = null, int? maxResultCounts = null)
        {
            var apiRequestData = new NearbySearchApiRequestModel(locationRestriction)
            {
                IncludedTypes = includedTypes,
                MaxResultCounts = maxResultCounts
            };
            var result = await SendRequestAsync<NearbySearchRequest, NearbySearchApiRequestModel, PlaceDetailApiResponseModel>(apiRequestData);
            return result.GetPlaceDetail();
        }

        public async Task<List<PlaceSimpleModel>> AutoCompleteAsync(string input, CircleModel locationRestriction = null)
        {
            var apiRequestData = new AutoCompleteApiRequestModel(input, locationRestriction);
            var result = await SendRequestAsync<AutoCompleteRequest, AutoCompleteApiRequestModel, PlaceAutoCompleteApiResponseModel>(apiRequestData);
            return result.GetPlaceSuggestions();
        }
    }
}
