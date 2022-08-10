using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ERPServiceWeb
{
    public class LogWriter
    {
        static string m_exePath = string.Empty;

        public static void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    writeToFile(logMessage);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private static void writeToFile(string logMessage)
        {
            string path1 = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path1))
                Directory.CreateDirectory(path1);
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string str1;
            str1 = "\\Logs\\EventLog_";
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.Date;
            string str2 = dateTime.ToShortDateString().Replace('/', '_');
            string str3 = ".txt";
            string path2 = baseDirectory + str1 + str2 + str3;
            logMessage = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " : " + logMessage + "\n---------------------------------------------------------------------";
            if (!File.Exists(path2))
            {
                using (StreamWriter text = File.CreateText(path2))
                    text.WriteLine(logMessage);
            }
            else
            {
                using (StreamWriter streamWriter = File.AppendText(path2))
                    streamWriter.WriteLine(logMessage);
            }
        }
    }
}