using GoogleMapSDK.API.Common.Models;
using GoogleMapSDK.Contract.API;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Common.Abstracts
{
    internal class AService
    {
        private readonly IServiceProvider _serviceProvider;

        public AService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected async Task<TResponseModel> SendRequestAsync<TRequest, TRequestModel, TResponseModel>(TRequestModel requestData)
            where TRequest : ARequest<TRequestModel, TResponseModel>
            where TResponseModel: AResponseModel
        {
            var request = _serviceProvider.GetService<TRequest>();
            request.RequestData = requestData;

            var response = await request.SendRequestAsync();
            response.GoogleMapAPI = _serviceProvider.GetService<IGoogleMapAPI>();
            return response;
        }
    }
}
