using GoogleMapSDK.API.Common.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Contract.Models;

namespace GoogleMapSDK.API.GeoCoding.JsonConverters
{
    public class LocationModelConverter : JsonConverter<LocationModel>
    {
        public override LocationModel ReadJson(JsonReader reader, Type objectType, LocationModel existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject token = JObject.Load(reader);

            // 支援 lat/lng 或 latitude/longitude 的 fallback 邏輯
            float lat = token["lat"]?.Value<float>()
                     ?? token["latitude"]?.Value<float>()
                     ?? 0f;

            float lng = token["lng"]?.Value<float>()
                     ?? token["longitude"]?.Value<float>()
                     ?? 0f;

            return new LocationModel
            {
                Latitude = lat,
                Longitude = lng
            };
        }

        public override void WriteJson(JsonWriter writer, LocationModel value, JsonSerializer serializer)
        {
            // 將物件轉成 "lat,lng" 字串格式
            writer.WriteValue($"{value.Latitude},{value.Longitude}");
        }
        public override bool CanRead => true;
        public override bool CanWrite => true;
    }
}
