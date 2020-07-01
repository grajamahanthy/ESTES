using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperVisionAPI.Models
{
    public class MVRResponseModel
    {
        public object Version { get; set; }
        public object RequestStatus { get; set; }
        public object ExternalReference { get; set; }
        public object Quoteback { get; set; }
        public object TimeStamp { get; set; }
        public Responseerror[] ResponseErrors { get; set; }
    }

    public class Responseerror
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
}