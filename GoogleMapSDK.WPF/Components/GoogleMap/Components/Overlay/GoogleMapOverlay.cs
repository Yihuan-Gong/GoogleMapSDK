using GMap.NET.WindowsPresentation;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Marker;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Overlay;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.WPF.Components.GoogleMap.Components.Overlay
{
    internal class GoogleMapOverlay: IGoogleMapOverlay
    {
        private List<IGoogleMapMarker> _markers = new List<IGoogleMapMarker>();
        private List<IGoogleMapRoute> _routes = new List<IGoogleMapRoute>();


        public List<IGoogleMapMarker> Markers { get => _markers; set => _markers = value; }

        public List<IGoogleMapRoute> Routes { get => _routes; set => _routes = value; }
    }
}
