using GoogleMapSDK.API.Extensions;
using GoogleMapSDK.Contract.Components.GoogleMap.Services;
using GoogleMapSDK.Core.Components.AutoComplete.Models;
using GoogleMapSDK.Core.Components.GoogleMap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVPExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Extensions
{
    public static class CoreRegistrationExtension
    {
        public static void AddCoreRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSingleton<GoogleMapAutoCompleteConfig>();
            serviceCollection.AddTransient<IOverlayService, OverlayService>();

            serviceCollection.AddAPIRegistration(configuration);
            serviceCollection.RegisterAllViewsAndPresenters(null);
        }
    }
}
