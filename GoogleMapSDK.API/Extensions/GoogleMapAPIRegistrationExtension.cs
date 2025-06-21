using HttpRequestModule.Auth;
using HttpRequestModule.Config;
using HttpRequestModule;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.Configurations;
using Microsoft.Extensions.Options;
using System.IO;
using GoogleMapSDK.Contract.API;

namespace GoogleMapSDK.API.Extensions
{
    public static class GoogleMapAPIRegistrationExtension
    {
        public static void AddAPIRegistration(this IServiceCollection serviceCollection,IConfiguration configuration)
        {
            serviceCollection.AddSingleton<IGoogleMapAPI, GoogleMapAPI>();
            serviceCollection.GoogleMapAPIConfigRegistration(configuration);
        }

        public static void GoogleMapAPIConfigRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //serviceCollection.Configure<GoogleMapAPIConfig>(configuration.GetSection("GoogleMapAPI"));
            serviceCollection.AddSingleton(sp =>
            {
                //var apiConfig = sp.GetService<IOptions<GoogleMapAPIConfig>>();
                //string apiKey = apiConfig.Value.ApiKey;

                var apiConfig = configuration.GetSection("GoogleMapAPI").Get<GoogleMapAPIConfig>();
                var apiKey = apiConfig.ApiKey;

                return new HttpRequest(new HttpRequestConfig
                {
                    BaseUrl = null,
                    Authenticator = new HeaderAuthenticator("X-Goog-Api-Key", apiKey),
                });
            });
        }
    }
}
