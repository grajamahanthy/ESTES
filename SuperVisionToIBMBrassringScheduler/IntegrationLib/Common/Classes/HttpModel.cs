using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib.Common.Classes
{
    public class HttpModel
    {
        public string Url { get; set; }
        public bool IsBasicAuthEnabled { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string paramsData { get; set; }
    }
}
