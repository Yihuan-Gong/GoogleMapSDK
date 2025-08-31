using GMap.NET.WindowsPresentation;
using GoogleMapSDK.Contract.Components.GoogleMap;
using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using GoogleMapSDK.Contract.Components.GoogleMap.Services;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.WPF.Components.GoogleMap.Views
{
    internal class GoogleMapView : GMapControl, IGoogleMapView
    {
        private readonly IOverlayService _overlayService;

        public GoogleMapView(IOverlayService overlayService)
        {
            _overlayService = overlayService;
        }

        //public void AddMarker(LocationModel location, GMap.NET.WindowsForms.Markers.GMarkerGoogleType markerType = 1, ToolTipModel toolTip = null, string overlayId = null)
        //{
        //    throw new NotImplementedException();
        //}

        public void AddRoute(string encodedPolyline, Color color = Color.Navy, double thickness = 5, string overlayId = null)
        {
            _overlayService.AddRoute(encodedPolyline, color, thickness, overlayId);
        }

        public void Hide(string overlayId)
        {
            throw new NotImplementedException();
        }

        public void HideAll()
        {
            throw new NotImplementedException();
        }

        public void Show(string overlayId)
        {
            throw new NotImplementedException();
        }

        public void ShowAll()
        {
            var markers = _overlayService.Overlays.Select(x => x.Value).Select(overlay =>
            {
                var list = new List<GMapMarker>();
                list.AddRange(overlay.Markers.Select(x => (GMapMarker)x));
                list.AddRange(overlay.Routes.Select(x => (GMapMarker)x));
                return list;
            }).SelectMany(x => x);

            foreach (var marker in markers)
            {
                Markers.Add(marker);
            }
        }
    }
}
