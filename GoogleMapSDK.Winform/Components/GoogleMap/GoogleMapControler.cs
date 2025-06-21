using GMap.NET;
using GMap.NET.ObjectModel;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GoogleMapSDK.Winform.Components.GoogleMap.Context;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using GoogleMapSDK.Contract.Components.GoogleMap;

namespace GoogleMapSDK.Map
{
    public class GoogleMapControler : GMapControl, IGoogleMapView
    {
        private readonly Dictionary<string, GMapOverlay> _overlays
            = new Dictionary<string, GMapOverlay>();

        public event EventHandler<LocationModel> OnMapLocationClick;

        public GoogleMapControler()
        {
           base.OnMapClick += MapClicked;
        }

        public void AddMarker(LocationModel location, GMarkerGoogleType markerType = GMarkerGoogleType.arrow, 
            ToolTipModel toolTip = null, string overlayId = null)
        {
            var editor = new GMapMarkerEditor(_overlays);
            editor.AddMarker(location, markerType, toolTip, overlayId);
        }

        public void AddRoute(string encodedPolyline, Pen routePen = null, string overlayId = null)
        {
            var editor = new GMapRouteEditor(_overlays);
            editor.AddRoute(encodedPolyline, routePen, overlayId);
        }

        public void ShowAll()
        {
            Overlays.Clear();

            foreach (var overlayPair in _overlays)
            {
                Overlays.Add(overlayPair.Value);
            }

            RefreshMap();
        }

        public void Show(string overlayId)
        {
            Overlays.Clear();

            GMapOverlay overlay = GetOverlay(overlayId);
            if (overlay != null)
                Overlays.Add(overlay);

            RefreshMap();
        }

        public void HideAll()
        {
            Overlays.Clear();

            RefreshMap();
        }

        public void Hide(string overlayId)
        {
            GMapOverlay overlay = GetOverlay(overlayId);
            if (overlay != null)
                Overlays.Remove(overlay);

            RefreshMap();
        }

        private GMapOverlay GetOverlay(string overlayId)
        {
            if (_overlays.ContainsKey(overlayId))
                return _overlays[overlayId];

            return null;
        }

        private void MapClicked(PointLatLng loc, MouseEventArgs e)
        {
            var location = new LocationModel
            {
                Latitude = (float)loc.Lat,
                Longitude = (float)loc.Lng,
            };

            OnMapLocationClick?.Invoke(this, location);
        }

        /// <summary>
        /// 處理Overlay刷新後，Map卻無法及時顯示的bug
        /// </summary>
        private void RefreshMap()
        {
            Zoom++;
            Zoom--;
        }
    }
}
