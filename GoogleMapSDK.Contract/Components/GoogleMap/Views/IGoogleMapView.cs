using GMap.NET.WindowsForms.Markers;
using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Components.GoogleMap
{
    public interface IGoogleMapView
    {
        void AddMarker(LocationModel location, MarkerType marker = MarkerType.arrow, string overlayId = null);

        void AddRoute(string encodedPolyline, Color color = Color.Navy, double thickness = 5, string overlayId = null);

        void ShowAll();

        void Show(string overlayId);

        void HideAll();

        void Hide(string overlayId);
    }
}
