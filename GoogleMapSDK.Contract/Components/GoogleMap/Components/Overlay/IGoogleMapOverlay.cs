using GMap.NET.WindowsForms;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Marker;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Components.GoogleMap.Components.Overlay
{
    public interface IGoogleMapOverlay
    {
        List<IGoogleMapMarker> Markers { get; }
        void AddMarker(IGoogleMapMarker marker);

        List<IGoogleMapRoute> Routes { get; set; }
    }
}
