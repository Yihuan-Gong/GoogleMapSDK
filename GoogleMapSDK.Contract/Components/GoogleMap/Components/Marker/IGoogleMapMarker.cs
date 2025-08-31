using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Components.GoogleMap.Components.Marker
{
    public interface IGoogleMapMarker
    {
        void Load(LocationModel location, MarkerType marker = MarkerType.arrow);
    }
}
