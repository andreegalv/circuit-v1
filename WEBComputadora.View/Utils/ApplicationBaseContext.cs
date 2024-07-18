using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace WEBComputadora.View.Utils
{
    public class ApplicationBaseContext
    {
        public static string GetSiteRootUrl()
        {
            var request = HttpContext.Current.Request;
            StringBuilder sb = new StringBuilder();

            sb.Append("http");
            if (request.IsSecureConnection)
                sb.Append("s");

            sb.Append("://");
            sb.Append(request.ServerVariables["SERVER_NAME"]);

            string port = request.ServerVariables["SERVER_PORT"];
            if (port != null && !port.Equals("80") && !port.Equals("443"))
                sb.Append(":" + port);

            return sb.ToString();
        }
        public static string GetFolderPath(ApplicationFolderPathName pathName)
        {
            string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            baseDirectoryPath = Path.GetFullPath(Path.Combine(baseDirectoryPath, @"..\"));
            string mainDirectoryPath = string.Empty;

            switch(pathName)
            {
                case ApplicationFolderPathName.LOGTEMP:
                    mainDirectoryPath = Path.Combine(baseDirectoryPath, "LOGTEMP");
                    break;
                default:
                    throw new NotImplementedException();
            }

            try
            {
                if (!Directory.Exists(mainDirectoryPath))
                {
                    Directory.CreateDirectory(mainDirectoryPath);
                }

                if (Directory.Exists(mainDirectoryPath))
                    return mainDirectoryPath;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
        public static void SaveSession(string sessionName, object obj)
        {
            var session = HttpContext.Current.Session;

            if (string.IsNullOrEmpty(sessionName))
                throw new Exception("You need to provide a valid session name");

            session.Add(sessionName, obj);
        }
        public static void SaveSession(string sessionName, string sessionNameDesc, object obj)
        {
            SaveSession(sessionName + "_" + sessionNameDesc, obj);
        }
        public static object GetSession(string sessionName)
        {
            var session = HttpContext.Current.Session;

            if (string.IsNullOrEmpty(sessionName))
                throw new Exception("You need to provide a valid session name");

            return session[sessionName];
        }
        public static object GetSession(string sessionName, string sessionNameDesc)
        {
            return GetSession(sessionName + "_" + sessionNameDesc);
        }
        public static void RemoveSession(string sessionName)
        {
            var session = HttpContext.Current.Session;
            session.Remove(sessionName);
        }
        public static void RemoveSession(string sessionName, string sessionNameDesc)
        {
            RemoveSession(sessionName + "_" + sessionNameDesc);
        }
    }
}