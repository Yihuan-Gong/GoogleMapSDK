using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Components.GoogleMap.Components.Route
{
    public interface IGoogleMapRoute
    {
        void Load(string polyline, Color color, double thickness = 5);
    }
}
