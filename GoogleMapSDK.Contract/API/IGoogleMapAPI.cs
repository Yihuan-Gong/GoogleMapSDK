using GoogleMapSDK.Contract.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.API
{
    public interface IGoogleMapAPI
    {
        IPlaceService PlaceService { get; }
        IGeoCodingService GeoCodingService { get; }
    }
}
