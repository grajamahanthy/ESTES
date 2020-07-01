using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLib.Common.Classes
{
    public class FtpModel
    {
        public string FtpFolderPath { set; get; }
        public string Host { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string KeyFilePath { set; get; }
        public string LocalTempProcDirectory { get; set; }
    }
}
