using GMap.NET;
using GMap.NET.WindowsForms;
using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Winform.Components.GoogleMap.Context
{
    internal class GMapRouteEditor : GMapEditor
    {
        public GMapRouteEditor(Dictionary<string, GMapOverlay> overlays) : base(overlays)
        {
        }

        public void AddRoute(string encodedPolyline, Pen routePen = null, string overlayId = null)
        {
            List<PointLatLng> points = PureProjection.PolylineDecode(encodedPolyline);
            GMapRoute route = new GMapRoute(points, "route")
            {
                Stroke = routePen
            };
            GMapOverlay overlay = GetOrCreateOverlay(overlayId);
            overlay.Routes.Add(route);
        }
    }
}
