using IntegrationLib.Common;
using IntegrationLib.Common.Classes;
using IntegrationLib.IntegrationHelpers;
using IntegrationLib.IntegrationHelpers.IBMBrassringToFroSuperVision;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace SuperVisionToIBMBrassringScheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            try
            {
                Integration integrationObj = new Integration();
                integrationObj.intBase.Run();
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
            }
        }
    }

    public class Integration
    {
        public IntegrationBase intBase { get; set; }
        public Integration()
        {
            string configFolder = ConfigurationManager.AppSettings["IntegrationFiles"].ToString();
            string configPath = configFolder + @"Config\Config.xml";
            this.intBase = new SuperVisionToIBMBrassring(configPath);
        }
    }
}
