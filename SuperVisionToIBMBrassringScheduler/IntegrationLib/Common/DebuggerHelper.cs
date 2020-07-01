using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib.Common
{
    public static class DebuggerHelper
    {
        public static void WriteExceptionToDebugFile(string inputString)
        {
            WriteExceptionToDebugFileAsync(inputString).GetAwaiter().GetResult();
        }

        public static void WriteToDebugFile(string inputString)
        {
            WriteToDebugFileAsync(inputString).GetAwaiter().GetResult();
        }

        public static async Task WriteExceptionToDebugFileAsync(string inputString)
        {
            try
            {
                string debugLoggerPath = ConfigurationManager.AppSettings["IntegrationFiles"].ToString() + @"DebuggerLogs\ExceptionLog.txt";
                using (StreamWriter streamWriter = File.AppendText(debugLoggerPath))
                {
                    streamWriter.WriteLine($"--------------------------------{DateTime.Now} START------------------------------");
                    streamWriter.WriteLine($"{inputString}");
                    streamWriter.WriteLine($"--------------------------------{DateTime.Now} END------------------------------");
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            catch (IOException ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile("*");
                await WriteExceptionToDebugFileAsync(inputString);
            }
        }

        public static async Task WriteToDebugFileAsync(string inputString)
        {
            try
            {
                string debugLoggerPath = ConfigurationManager.AppSettings["IntegrationFiles"].ToString() + @"DebuggerLogs\ExceptionLog.txt";
                using (StreamWriter streamWriter = File.AppendText(debugLoggerPath))
                {
                    streamWriter.WriteLine($"--------------------------------{DateTime.Now} START------------------------------");
                    streamWriter.WriteLine($"{inputString}");
                    streamWriter.WriteLine($"--------------------------------{DateTime.Now} END------------------------------");
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            catch (IOException ex)
            {
                DebuggerHelper.WriteExceptionToDebugFile("*");
                await WriteToDebugFileAsync(inputString);
            }
        }
    }
}
