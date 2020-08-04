using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Data
    {
        public static readonly string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\macedonga\actions\";
        public static string endpoint = @"https://actions.macedon.ga/";
        public static string UID;
        public static string Token;
        public static string RequestData;
        public static bool isDebug = false;
        public static bool localEndpoint = false;
        public static string processName = "";
        public static int processID = 0;
    }
    class Login
    {
        public bool Success { get; set; }
        public string UID { get; set; }
        public string Token { get; set; }
    }
    class Programs
    {
        public static string[] Spotify = {"Spotify", "Spotify.exe" , @"https://cdn.macedon.ga/actions/spotify.png"};//
        public static string[] VSCode = {"Code", "Code.exe", @"https://cdn.macedon.ga/actions/code.png"};//
        public static string[] VS = {"Visual Studio", "devenv.exe", @"https://cdn.macedon.ga/actions/vs.png"};//
        public static string[] VSBlend = {"Blend for Visual Studio", "Blend.exe", @"https://cdn.macedon.ga/actions/vs-blend.png"};//
        public static string[] GitHubDesktop = { "GitHub Desktop", "GitHubDesktop.exe", @"https://cdn.macedon.ga/actions/github.png"};//
        public static string[] AndroidStudio = { "Android Studio", "studio64.exe", @"https://cdn.macedon.ga/actions/android.studio.png"};//
        public static string[] Dreamweaver = { "Adobe Dreamweaver", "Dreamweaver.exe", @"https://cdn.macedon.ga/actions/dreamweaver.png" };//
        public static string[] IntelliJIdea = { "IntelliJ Idea", "idea64.exe", @"https://cdn.macedon.ga/actions/idea.png" };//
        public static string[] Illustrator = { "Adobe Illustrator", "Illustrator.exe", @"https://cdn.macedon.ga/actions/illustrator.png" };//
        public static string[] InDesign = { "Adobe InDesign", "InDesign.exe", @"https://cdn.macedon.ga/actions/indesign.png" };//
        public static string[] Notepad = { "Notepad++", "notepad++.exe", @"https://cdn.macedon.ga/actions/notepad.png" };//
        public static string[] Photoshop = { "Adobe Photoshop", "Photoshop.exe", @"https://cdn.macedon.ga/actions/photoshop.png" };//
        public static string[] Premiere = { "Adobe Premiere", "Premiere.exe", @"https://cdn.macedon.ga/actions/premiere.png" };//
        public static string[] Solidworks = { "DS Solidworks", "SLDWORKS.exe", @"https://cdn.macedon.ga/actions/solidworks.png" };//
        public static string[] Blender = { "Blender", "blender.exe", @"https://cdn.macedon.ga/actions/blender.png" };//
        public static string[] Gimp = { "Gimp", "Gimp.exe", @"https://cdn.macedon.ga/actions/gimp.png" };
        public static string[] Ubuntu = { "WSL - Ubuntu", "ubuntu.exe", @"https://cdn.macedon.ga/actions/ubuntu.png" };
    }
    class Requests
    {
        /// <summary> Makes a request to the API to set the status </summary>
        /// <returns> Return true if a request was succesfully made to the API, or else it will return false </returns>
        /// <param name="status"> Action name </param>
        /// <param name="image"> Action image link </param>
        public static bool Set(string status, string image)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Data.endpoint + "set");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"uid\":\"" + Data.UID + "\"," +
                                  "\"status\":\"" + status + "\"," +
                                  "\"token\":\"" + Data.Token + "\"";
                    if (image != null)
                        json += ",\"image\":\"" + image + "\"}";
                    else
                        json += "}";

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result.Contains("true"))
                        return true;
                    else
                        return false;

                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary> Makes a request to the API to reset the status </summary>
        /// <returns> Return true if a request was succesfully made to the API, or else it will return false </returns>
        public static bool Reset()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Data.endpoint + "reset");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"uid\":\"" + Data.UID + "\"," +
                                  "\"token\":\"" + Data.Token + "\"}";

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result.Contains("true"))
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
