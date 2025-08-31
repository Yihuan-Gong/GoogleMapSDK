using GoogleMapSDK.Contract.Components.GoogleMap.Components.Marker;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Overlay;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Route;
using GoogleMapSDK.Winform.Components.GoogleMap.Components.Marker;
using GoogleMapSDK.Winform.Components.GoogleMap.Components.Overlay;
using GoogleMapSDK.Winform.Components.GoogleMap.Components.Route;
using Microsoft.Extensions.DependencyInjection;
using MVPExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Winform.Extensions
{
    public static class WinformRegistrationExtension
    {
        public static void AddWinformRegistration(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterAllViewsAndPresenters(null);

            serviceCollection.AddTransient<IGoogleMapMarker, GoogleMapMarker>();
            serviceCollection.AddTransient<IGoogleMapRoute, GoogleMapRoute>();
            serviceCollection.AddTransient<IGoogleMapOverlay, GoogleMapOverlay>();
        }
    }
}
