using GMap.NET;
using GMap.NET.WindowsForms;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Route;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Winform.Extensions;

namespace GoogleMapSDK.Winform.Components.GoogleMap.Components.Route
{
    internal class GoogleMapRoute : GMapRoute, IGoogleMapRoute
    {
        // 這裡要討論使用繼承還是Adapter，哪個比較好
        // 我個人是覺得可以使用Adapter，然後把IGoogleMapRoute換成abstract
        // 共同封裝PureProjection.PolylineDecode(polyline)
        // 另外也要討論，是否加上一個Property來輸出GMapRoute (object)
        // 用來放入實體Overlay (GoogleMapOverlay)
        public GoogleMapRoute() : base(string.Empty)
        {
        }

        public void Load(string polyline, Contract.Components.GoogleMap.Models.Color color, double thickness = 5)
        {
            Points.AddRange(PureProjection.PolylineDecode(polyline));
            Stroke = new Pen(color.GetWinformColor(), (float)thickness);
        }
    }
}
