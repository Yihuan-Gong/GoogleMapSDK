using GMap.NET.WindowsForms;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Marker;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Overlay;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Route;
using GoogleMapSDK.Winform.Components.GoogleMap.Components.Marker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Winform.Components.GoogleMap.Components.Overlay
{
    internal class GoogleMapOverlay : IGoogleMapOverlay
    {
        // GoogleMapOverlay 也是，可以考慮繼承和Adapter哪個好
        // 在沒有base constructor的時候可以用直接繼承
        // 但有base constructor的時候只能使用Adapter比較安全

        private readonly GMapOverlay _overlay;

        public GMapOverlay Overlay { get => _overlay; }

        public GoogleMapOverlay()
        {
            _overlay = new GMapOverlay();
        }

        public List<IGoogleMapMarker> Markers
        {
            get => _overlay.Markers.Select(x =>
            {
                var marker = new GoogleMapMarker();
                marker.Load(x);
                return (IGoogleMapMarker)marker;
            }).ToList();

            // 這邊很像無法執行
            //set
            //{
            //    _overlay.Markers.Clear();
            //    foreach (var marker in value)
            //    {
            //        _overlay.Markers.Add(((GoogleMapMarker)marker).Marker);
            //    }
            //}
        }

        public void AddMarker(IGoogleMapMarker marker)
        {
            _overlay.Markers.Add(((GoogleMapMarker)marker).Marker);
        }

        public List<IGoogleMapRoute> Routes
        {
            get => _overlay.Markers.Select(x => x as IGoogleMapRoute).ToList();

            set
            {
                _overlay.Routes.Clear();
                foreach (var route in value)
                {
                    _overlay.Routes.Add(route as GMapRoute);
                }
            }
        }
    }
}
