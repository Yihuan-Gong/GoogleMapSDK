using HttpRequestModule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Common.Abstracts
{
    public abstract class APostRequest<TRequestModel, TResponseModel> : ARequest<TRequestModel, TResponseModel>
    {
        protected APostRequest(HttpRequest httpRequest) : base(httpRequest)
        {
        }

        protected override JsonSerializerSettings JsonSerializerSettings => throw new NotImplementedException();
        protected abstract PropertyMode BodyFormat { get; }
        protected abstract Dictionary<string, string> Header { get; }

       
        public override async Task<TResponseModel> SendRequestAsync()
        {
            foreach (var item in Header)
            {
                httpRequest.AddHeader(item.Key, item.Value);
            }
            
            return await httpRequest.PostAsync<TResponseModel>(TotalUrl, RequestData, propertyMode: BodyFormat);
        }
    }
}
