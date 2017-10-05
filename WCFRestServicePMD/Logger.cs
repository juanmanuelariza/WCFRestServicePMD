using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WCFRestServicePMD
{
    public class Logger
    {
        public static void log(string message)
        {
            try
            {
                DateTime datetime = DateTime.Now;
                string oFileName = HostingEnvironment.ApplicationPhysicalPath + "progMilDias_" + datetime.ToString("yyyyMM") + ".log";
                if (!File.Exists(oFileName))
                {
                    FileStream f = File.Create(oFileName);
                    f.Close();
                }

                StreamWriter writter = File.AppendText(oFileName);
                writter.WriteLine(datetime.ToString("dd-MM-yyyy hh:mm") + " > " + message);
                writter.Flush();
                writter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                EventLog.WriteEntry("WCFServicePMD", e.Message, EventLogEntryType.Error);
            }
        }
    }
}