using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Checks if a debug argument is given
            if (args.Length != 0)
                bool.TryParse(args[0], out Data.isDebug);
            if (args.Length >= 1)
                bool.TryParse(args[0], out Data.localEndpoint);
            if (Data.localEndpoint)
                Data.endpoint = "http://localhost:5555/";

            FirstBoot();
            GetProcesses();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary> 
        /// This is a startup check of all the processes and if there is a supported program it makes a request to the API 
        /// </summary>
        static void GetProcesses()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                if (ActionSet.CheckProc(p.ProcessName))
                {
                    Data.processID = p.Id;
                    Data.processName = p.ProcessName;
                    break;
                }
            }
        }

        /// <summary>
        /// If the "login.json" file doesn't exist, it creates one and makes a request to the API to register an URL
        /// IF the "login.json" file exists it will get the login data from it
        /// </summary>
        static void FirstBoot()
        {
            if (!File.Exists(Data.DataPath + "login.json"))
            {
                Directory.CreateDirectory(Data.DataPath);
                string url = Data.endpoint + "register";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    Data.RequestData = reader.ReadToEnd();
                    Login login = JsonConvert.DeserializeObject<Login>(Data.RequestData);
                    File.WriteAllText(Data.DataPath + "login.json", Data.RequestData);
                    Data.UID = login.UID;
                    Data.Token = login.Token;
                }
            }
            else
            {
                string json = File.ReadAllText(Data.DataPath + "login.json");
                Login data = JsonConvert.DeserializeObject<Login>(json);
                Data.UID = data.UID;
                Data.Token = data.Token;
            }
        }
    }
}
