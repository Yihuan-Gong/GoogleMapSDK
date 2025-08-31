using GoogleMapSDK.Contract.Components.GoogleMap.Components.Overlay;
using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Components.GoogleMap.Services
{
    public interface IOverlayService
    {
        Dictionary<string, IGoogleMapOverlay> Overlays { get; }

        void AddMarker(LocationModel location, MarkerType markerType, string overlayId = null);
        void AddRoute(string encodedPolyline, Color color, double thickness, string overlayId = null);
    }
}
