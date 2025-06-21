using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using GoogleMapSDK.Contract.Models;
using GoogleMapSDK.Winform.Components.GoogleMap.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Winform.Components.GoogleMap.Context
{
    internal class GMapMarkerEditor : GMapEditor
    {
        public GMapMarkerEditor(Dictionary<string, GMapOverlay> overlays) : base(overlays)
        {
        }

        public void AddMarker(LocationModel location, GMarkerGoogleType markerType = GMarkerGoogleType.arrow,
            ToolTipModel toolTip = null, string overlayId = null)
        {
            GMapOverlay overlay = GetOrCreateOverlay(overlayId);
            GMapMarker gMapMarker = new GMarkerGoogle(LocationConversion(location), markerType);
            
            if (toolTip != null)
            {
                var toolTipInstance = new GMapToolTip(gMapMarker);
                MemberCopier.Copy(toolTip, toolTipInstance);

                gMapMarker.ToolTipText = toolTip.Text;
                gMapMarker.ToolTip = toolTipInstance;
            }

            overlay.Markers.Add(gMapMarker);
        }

        private PointLatLng LocationConversion(LocationModel location)
        {
            return new PointLatLng(location.Latitude, location.Longitude);
        }
    }
}
