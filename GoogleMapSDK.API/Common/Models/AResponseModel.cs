using GoogleMapSDK.Contract.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Common.Models
{
    public abstract class AResponseModel
    {
        public IGoogleMapAPI GoogleMapAPI { get; set; }
    }
}
