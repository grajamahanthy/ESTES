using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IntegrationLib.Common.Classes
{
    public class LoggerModel
    {
        public string FileName { get; set; }
        public FtpModel FtpConfig { get; set; }
        public string LocationType { get; set; }
        public FileModel FileConfig { get; set; }        
    }
}
