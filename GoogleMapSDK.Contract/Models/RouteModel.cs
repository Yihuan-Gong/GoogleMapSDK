using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Components.GoogleMap.Models
{
    public class RouteModel
    {
        public PolylineModel Polyline { get; set; }

        public class PolylineModel
        {
            public string EncodedPolyline { get; set; }
        }
    }

}
