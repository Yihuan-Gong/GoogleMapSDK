using GoogleMapSDK.Contract.Components.GoogleMap.Components.Marker;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Overlay;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Route;
using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using GoogleMapSDK.Contract.Components.GoogleMap.Services;
using GoogleMapSDK.Contract.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.GoogleMap
{
    public class OverlayService : IOverlayService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, IGoogleMapOverlay> _overlays;
        private int _defaultOverlayNum = 0;

        public Dictionary<string, IGoogleMapOverlay> Overlays => _overlays;

        public OverlayService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _overlays = new Dictionary<string, IGoogleMapOverlay>();
        }

        public void AddMarker(LocationModel location, MarkerType markerType, string overlayId = null)
        {
            var marker = _serviceProvider.GetService<IGoogleMapMarker>();
            marker.Load(location, markerType);
            
            IGoogleMapOverlay overlay = GetOrCreateOverlay(overlayId);
            overlay.AddMarker(marker);
        }

        public void AddRoute(string encodedPolyline, Color color, double thickness, string overlayId = null)
        {
            var route = _serviceProvider.GetService<IGoogleMapRoute>();
            route.Load(encodedPolyline, color, thickness);

            IGoogleMapOverlay overlay = GetOrCreateOverlay(overlayId);
            overlay.Routes.Add(route);
        }

        /// <summary>
        /// 回傳GMapOverlay圖層，如果沒有該overlayId則創建並回傳新圖層，
        /// 若overlayId為null則使用內建overlayId
        /// </summary>
        /// <param name="overlayId"></param>
        /// <returns></returns>
        private IGoogleMapOverlay GetOrCreateOverlay(string overlayId = null)
        {
            if (overlayId == null)
            {
                _defaultOverlayNum++;
                overlayId = $"Overlay {_defaultOverlayNum}";
                return CreateOverlay(overlayId);
            }

            if (_overlays.ContainsKey(overlayId))
            {
                return _overlays[overlayId];
            }

            return CreateOverlay(overlayId);
        }

        private IGoogleMapOverlay CreateOverlay(string overlayId)
        {
            var overlay = _serviceProvider.GetService<IGoogleMapOverlay>();
            _overlays.Add(overlayId, overlay);
            return overlay;
        }
    }
}
