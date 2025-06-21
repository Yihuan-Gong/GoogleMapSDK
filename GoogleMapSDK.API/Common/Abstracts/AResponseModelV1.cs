using GoogleMapSDK.API.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Common.Abstracts
{
    internal abstract class AResponseModelV1: AResponseModel
    {
        public string ErrorMessage { get; set; }
        public string Status { get; set; }

        protected void CheckStatusOrThrowException()
        {
            if (Status != "OK")
            {
                throw new Exception(ErrorMessage);
            }
        }
    }
}
