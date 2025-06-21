using GoogleMapSDK.API.Common.Abstracts;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places.Models
{
    internal class PlaceAutoCompleteApiResponseModel : AResponseModelV2
    {
        public List<PlaceSuggestionModel> Suggestions { get; set; }

        public List<PlaceSimpleModel> GetPlaceSuggestions()
        {
            CheckSucussesOrThrowException();

            return Suggestions.Select(x => new PlaceSimpleModel(GoogleMapAPI)
            {
                Id = x.PlacePrediction.PlaceId,
                Name = x.PlacePrediction.Text.Text,
            }).ToList();
        }
    }

    internal class PlaceSuggestionModel
    {
        public PlacePredictionModel PlacePrediction { get; set; }

        public class PlacePredictionModel
        {
            public string PlaceId { get; set; }
            public TextModel Text { get; set; }

            public class TextModel
            {
                public string Text { get; set; }
                public List<MatchModel> Matches { get; set; }

                public class MatchModel
                {
                    public int EndOffset { get; set; }
                }
            }
        }
    }
}
