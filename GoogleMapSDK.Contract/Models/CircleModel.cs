using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models
{
    public class CircleModel
    {
        public LocationModel Center { get; set; }
        /// <summary>
        /// Radius in meters
        /// </summary>
        public float Radius { get; set; }
    }
}
