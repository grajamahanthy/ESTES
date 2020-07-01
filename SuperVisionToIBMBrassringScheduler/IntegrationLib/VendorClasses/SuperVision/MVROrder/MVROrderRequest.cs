using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib.VendorClasses.SuperVision
{
    public class MVROrderRequest
    {
        public Requestdetails requestDetails { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }

    public class Requestdetails
    {
        public Requestclientdata requestClientData { get; set; }
        public Requestdriverdata[] requestDriverData { get; set; }
        public string externalReference { get; set; }
    }

    public class Requestclientdata
    {
        public int clientID { get; set; }
        public string clientName { get; set; }
        public string destinationUrl { get; set; }
    }

    public class Requestdriverdata
    {
        public string driverReferenceNumber { get; set; }
        public string licenseNumber { get; set; }
        public string licenseState { get; set; }
        public string cdlStatus { get; set; }
        public string reportType { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string birthDate { get; set; }
        public string quoteback { get; set; }
        public string allowMultipleMVROrdersPerDay { get; set; }
        public string socialSecurityNumber { get; set; }
    }
}
