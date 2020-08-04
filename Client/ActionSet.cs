using System;
using System.Management;
using System.Diagnostics;

namespace Client
{
    class ActionSet
    {
        private static ManagementEventWatcher startWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
        private static ManagementEventWatcher stopWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
        public static bool isRunning;

        /// <summary> Starts the process watcher </summary>
        public static void Start()
        {
            startWatch.EventArrived += new EventArrivedEventHandler(StartWatch);
            startWatch.Start();

            stopWatch.EventArrived += new EventArrivedEventHandler(StopWatch);
            stopWatch.Start();
            isRunning = true;
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                if (CheckProc(p.ProcessName))
                {
                    Data.processID = p.Id;
                    Data.processName = p.ProcessName;
                    break;
                }
            }
        }

        /// <summary> Stops the process watcher </summary>
        public static void Stop()
        {
            startWatch.EventArrived -= new EventArrivedEventHandler(StartWatch);
            startWatch.Stop();

            stopWatch.EventArrived -= new EventArrivedEventHandler(StopWatch);
            stopWatch.Stop();
            isRunning = false;
        }

        /// <summary> Called when a process starts </summary>
        static void StartWatch(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            int processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value);
            if (Data.isDebug)
                Console.WriteLine("Process started. Executable name: " + processName + " | ID: " + processID.ToString());
            if (Data.processID == 0)
                if (CheckProc(processName))
                {
                    Data.processID = processID;
                    Data.processName = processName;
                }
        }

        /// <summary> Called when a process stops </summary>
        static void StopWatch(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            int processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value);
            if(Data.isDebug)
                Console.WriteLine("Process stopped. Executable name: " + processName + " | ID: " + processID.ToString());
            if (processID == Data.processID && processName == Data.processName)
            {
                Requests.Set("idle", "none");
                Data.processID = 0;
                Data.processName = "";
            }
        }

        /// <summary> Checks the given process and if it is a supported program it will make a request to the API. </summary>
        /// <returns> Return true if a request was made to the API </returns>
        /// <param name="processName"> Process name </param>
        /// TODO: Remove hardcoded data
        public static bool CheckProc(string processName)
        {
            if (processName.ToLower().Contains("spotify"))
            {
                Requests.Set("Listening to Spotify", Programs.Spotify[2]);
                return true;
            }
            else if (processName.ToLower().Contains("blender"))
            {
                Requests.Set("3D Modelling", Programs.Blender[2]);
                return true;
            }
            else if (processName.ToLower().Contains("blend"))
            {
                Requests.Set("Blend", Programs.VSBlend[2]);
                return true;
            }
            else if (processName.ToLower().Contains("devenv"))
            {
                Requests.Set("Using Visual Studio", Programs.VS[2]);
                return true;
            }
            else if (processName.ToLower().Contains("code"))
            {
                Requests.Set("Using VS Code", Programs.VSCode[2]);
                return true;
            }
            else if (processName.ToLower().Contains("githubdesktop"))
            {
                Requests.Set("GitHub Desktop", Programs.GitHubDesktop[2]);
                return true;
            }
            else if (processName.ToLower().Contains("studio64"))
            {
                Requests.Set("Android Studio", Programs.AndroidStudio[2]);
                return true;
            }
            else if (processName.ToLower().Contains("dreamweaver"))
            {
                Requests.Set("Creating a website", Programs.Dreamweaver[2]);
                return true;
            }
            else if (processName.ToLower().Contains("idea64"))
            {
                Requests.Set("IntelliJ Idea", Programs.IntelliJIdea[2]);
                return true;
            }
            else if (processName.ToLower().Contains("illustrator"))
            {
                Requests.Set("Adobe Illustrator", Programs.Illustrator[2]);
                return true;
            }
            else if (processName.ToLower().Contains("indesign"))
            {
                Requests.Set("Adobe InDesign", Programs.InDesign[2]);
                return true;
            }
            else if (processName.ToLower().Contains("notepad++"))
            {
                Requests.Set("Notepad++", Programs.Notepad[2]);
                return true;
            }
            else if (processName.ToLower().Contains("photoshop"))
            {
                Requests.Set("Adobe Photoshop", Programs.Photoshop[2]);
                return true;
            }
            else if (processName.ToLower().Contains("premiere"))
            {
                Requests.Set("Video editing", Programs.Premiere[2]);
                return true;
            }
            else if (processName.ToLower().Contains("sldworks"))
            {
                Requests.Set("DS Soliworks", Programs.Solidworks[2]);
                return true;
            }
            else if (processName.ToLower().Contains("gimp"))
            {
                Requests.Set("Gimp", Programs.Gimp[2]);
                return true;
            }
            else if (processName.ToLower().Contains("ubuntu"))
            {
                Requests.Set("WSL - Ubuntu", Programs.Ubuntu[2]);
                return true;
            }
            else
                return false;
        }
    }
}
