using GoogleMapSDK.API.Extensions;
using HttpRequestModule;
using IoCContainer;
using IoCContainer.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // 問題：
            // 我覺得範例那包專案，花大量的code在處理user input到API request之間的轉換，
            // 在這過程中有很多的field name是重複且沒必要的。
            // 我覺得在我的專案中，可以把發request的class和request model分離。
            // 這樣發request的時候就直接使用request model，不需要多一層轉換的code。

            var serviceCollection = new IoCContainer.ServiceCollection();
            serviceCollection.AddSingleton<GoogleMapAPI>();
            //serviceCollection.GoogleMapAPIConfigRegistration();
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            var googleMapAPI = serviceProvider.GetService<GoogleMapAPI>();

            //var result = await googleMapAPI.RouteService.CreateDriveRoute(new Routes.Requests.Models.DriveRequestModel
            //{
            //    Origin = new Routes.Requests.Models.ARouteRequestModel.PlaceModel
            //    {
            //        PlaceId = "ChIJo-3Fwwg2aDQRcEMmon0R558"
            //    },
            //    Destination = new Routes.Requests.Models.ARouteRequestModel.PlaceModel
            //    {
            //        PlaceId = "ChIJH56c2rarQjQRphD9gvC8BhI"
            //    }
            //});

            //var result2 = await googleMapAPI.GeoCodingService.GetGeoCoding(new GeoCoding.Requests.Models.GeoCodingRequestModel
            //{
            //    Latlng = new Common.Models.LocationModel
            //    {
            //        Latitude = 43.0865f,
            //        Longitude = 141.33288f
            //    },
            //    Language = "zh-TW"
            //});

            //var result3 = await googleMapAPI.PlaceService.AutoCompleteAsync(new Places.Requests.Models.AutoCompleteApiRequestModel
            //{
            //    Input = "pizza",
            //    LocationBias = new Places.Requests.Models.AutoCompleteApiRequestModel.LocationBiasModel
            //    {
            //        Circle = new Places.Models.CircleModel
            //        {
            //            Center = new Common.Models.LocationModel
            //            {
            //                Latitude = 24.9545f,
            //                Longitude = 121.2105f
            //            },
            //            Radius = 1000
            //        }
            //    }
            //});

            Console.ReadKey();
        }
    }
}
