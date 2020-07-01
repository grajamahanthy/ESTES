using IntegrationLib.Common;
using IntegrationLib.Common.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IntegrationLib.IntegrationHelpers
{
    public abstract class IntegrationBase
    {
        public LoggerHelper logger;
        public Config config;
        public IntegrationBase(string configPath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(configPath);
                SerializationHelper sH = new SerializationHelper();
                config = sH.Deserialize<Config>(xmlDoc.OuterXml);
                logger = LoggerHelper.GetInstance(config);
            }
            catch (Exception ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile(ex.Message);
                throw ex;
            }

        }

        public abstract void Run(string inputXmlStr = null);
        public abstract Task<string> RunAndReturn(string inputXmlStr = null);

    }
}
