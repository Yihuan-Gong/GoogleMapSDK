using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.ObjectModel;
using GMap.NET.WindowsForms;
using GoogleMapSDK.Contract.Components.GoogleMap;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Overlay;
using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using GoogleMapSDK.Contract.Components.GoogleMap.Services;
using GoogleMapSDK.Contract.Models;
using GoogleMapSDK.Winform.Components.GoogleMap.Components.Overlay;
using System;
using System.Windows.Forms;

namespace GoogleMapSDK.Map
{
    public class GoogleMapControler : GMapControl, IGoogleMapView
    {
        private readonly IOverlayService _overlayService;

        public event EventHandler<LocationModel> OnMapLocationClick;

        public GoogleMapControler(IOverlayService overlayService)
        {
            _overlayService = overlayService;
            base.OnMapClick += MapClicked;

            MapProvider = GMapProviders.GoogleMap; // 设置地图源
            MinZoom = 0;
            MaxZoom = 24;
            Zoom = 12;
            Position = new PointLatLng(25, 121); // 地图中心位置
            ScaleMode = ScaleModes.Fractional;
            DragButton = MouseButtons.Left;
            Size = new System.Drawing.Size(400, 400);
        }

        public void AddMarker(LocationModel location, MarkerType marker = MarkerType.arrow, string overlayId = null)
        {
            _overlayService.AddMarker(location, marker, overlayId);
        }

        public void AddRoute(string encodedPolyline, Color color = Color.Navy, double thickness = 5, string overlayId = null)
        {
            _overlayService.AddRoute(encodedPolyline, color, thickness, overlayId);
        }

        public void ShowAll()
        {
            Overlays.Clear();

            foreach (var overlayPair in _overlayService.Overlays)
            {
                Overlays.Add(GetOverlay(overlayPair.Value));
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
            if (_overlayService.Overlays.ContainsKey(overlayId))
                return GetOverlay(_overlayService.Overlays[overlayId]);

            return null;
        }

        private GMapOverlay GetOverlay(IGoogleMapOverlay overlay)
        {
            return ((GoogleMapOverlay)overlay).Overlay;
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
