using System;
using System.IO;
using System.Reflection;
using PromotionEngine.HelperModule;
namespace PromotionEngine.Logging
{
    public class LogInfo
    {
        private static string localDirPath = string.Empty;

        /// <summary>
        /// Operation to write the log
        /// </summary>
        /// <param name="logMsg">Message that needs to be written</param>
        /// <param name="objWriter"> Writer Object</param>
        public static void WriteLog(string logMsg, TextWriter objWriter)
        {
            try
            {
                objWriter.Write("\r\n Start Logging : ");
                objWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                objWriter.WriteLine("  :{0}", logMsg);
                objWriter.WriteLine("-------------------------------");
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Operation for logging
        /// </summary>
        /// <param name="logMsg">Message that needs to be written</param>
        public static void LogMessage(string logMsg)
        {
            localDirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter objStream = File.AppendText(localDirPath + "\\" + EngineHelper.LogFileName))
                {
                    WriteLog(logMsg, objStream);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
