using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib.VendorClasses.SuperVision
{

    public class MVRResponse
    {
        public string Version { get; set; }
        public string RequestStatus { get; set; }
        public string ExternalReference { get; set; }
        public string Quoteback { get; set; }
        public string TimeStamp { get; set; }
        public object ResponseErrors { get; set; }
    }
}
