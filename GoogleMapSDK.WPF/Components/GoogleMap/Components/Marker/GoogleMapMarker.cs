using GMap.NET;
using GMap.NET.WindowsPresentation;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Marker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.WPF.Components.GoogleMap.Components.Marker
{
    internal class GoogleMapMarker : GMapMarker, IGoogleMapMarker
    {
        public GoogleMapMarker() : base(new PointLatLng())
        {
            
        }

        // 這裡要嘗試跟Winform一樣透過resource來生成marker

    }
}
