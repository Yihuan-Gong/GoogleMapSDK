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
        void AddMarker(LocationModel location, GMarkerGoogleType markerType = GMarkerGoogleType.arrow,
            ToolTipModel toolTip = null, string overlayId = null);

        void AddRoute(string encodedPolyline, Pen routePen = null, string overlayId = null);

        void ShowAll();

        void Show(string overlayId);

        void HideAll();

        void Hide(string overlayId);
    }
}
