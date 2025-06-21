using HttpRequestModule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Common.Abstracts
{
    public abstract class ARequest<TRequestModel, TResponseModel>
    {
        protected HttpRequest httpRequest;

        protected ARequest(HttpRequest httpRequest)
        {
            this.httpRequest = httpRequest;
        }

        public TRequestModel RequestData { get; set; }
        protected abstract JsonSerializerSettings JsonSerializerSettings { get; }
        protected abstract string TotalUrl { get; }

        /// <summary>
        /// Send API request 
        /// </summary>
        /// <returns></returns>
        public abstract Task<TResponseModel> SendRequestAsync();

        protected TResponseModel DeserializeResponse(string jsonResponse)
        {
            return JsonConvert.DeserializeObject<TResponseModel>(jsonResponse, JsonSerializerSettings);
        }
    }
}
