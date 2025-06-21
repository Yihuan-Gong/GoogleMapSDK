using GoogleMapSDK.API;
using GoogleMapSDK.API.Places.Models;
using GoogleMapSDK.API.Places.Requests.Models;
using GoogleMapSDK.Contract.API;
using GoogleMapSDK.Contract.AutoComplete.Models;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.AutoComplete.Models
{
    public class GoogleMapAutoCompleteConfig : IAutoCompleteConfig<PlaceSimpleModel>
    {
        private readonly IGoogleMapAPI _api;

        public GoogleMapAutoCompleteConfig(IGoogleMapAPI api)
        {
            _api = api;
        }

        public EventHandler<PlaceSimpleModel> AutoCompleteSelected
        {
            get => (s, place) =>
            {
                Console.WriteLine(place.Name);
            };
        }

        public async Task<Dictionary<string, PlaceSimpleModel>> GetValuesAsync(string inputText)
        {
            var response = await _api.PlaceService.AutoCompleteAsync(inputText);
            return response.ToDictionary(x => x.Name);
        }
    }
}
