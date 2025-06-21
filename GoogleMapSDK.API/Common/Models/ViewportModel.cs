using GoogleMapSDK.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Common.Models
{
    public class ViewportModel
    {
        public LocationModel Low { get; set; }
        public LocationModel High { get; set; }
    }
}
