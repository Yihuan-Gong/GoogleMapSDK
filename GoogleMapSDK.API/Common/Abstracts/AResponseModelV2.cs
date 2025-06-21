using GoogleMapSDK.API.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Common.Abstracts
{
    public abstract class AResponseModelV2: AResponseModel
    {
        public ErrorModel Error { get; set; }

        public class ErrorModel
        {
            public int Code { get; set; }
            public string Message { get; set; }
            public string Status { get; set; }
            public object Details { get; set; }
        }

        public void CheckSucussesOrThrowException()
        {
            if (Error != null)
            {
                throw new Exception(Error.Message);
            }
        }
    }
}
