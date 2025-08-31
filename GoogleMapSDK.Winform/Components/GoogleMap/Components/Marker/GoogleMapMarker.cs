using DTO;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Marker;
using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Winform.Components.GoogleMap.Components.Marker
{
    internal class GoogleMapMarker : IGoogleMapMarker
    {
        private GMapMarker _marker;

        public GMapMarker Marker { get => _marker; }

        public GoogleMapMarker()
        {
        }

        public void Load(LocationModel location, MarkerType marker = MarkerType.arrow)
        {
            var markerLocation = LocationConversion(location);
            var markerType = new Mapper<MarkerType, GMarkerGoogleType>().Map(marker);
            _marker = new GMarkerGoogle(markerLocation, markerType);
        }

        public void Load(GMapMarker marker)
        {
            _marker = marker;
        }

        private PointLatLng LocationConversion(LocationModel location)
        {
            return new PointLatLng(location.Latitude, location.Longitude);
        }
    }
}
