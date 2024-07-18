using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using WEBComputadora.View.Utils;
using WEBComputadora.View.Utils.Interfaces;

namespace WEBComputadora.View.Utils.Loggers
{
    public abstract class BaseLogger : ILogger
    {
        protected BaseLogger()
        {
            PathFile = ApplicationBaseContext.GetFolderPath(ApplicationFolderPathName.LOGTEMP);
            PathFile = Path.Combine(PathFile, "application_logger_" + DateTime.Now.ToString("dd-MM-yyyy") + ".logs");

            if (PathFile != null)
            {
                CheckFolderExists(true);
            }
        }

        protected string PathFile { get; private set; }
        protected bool FileExists { get; private set; }

        public abstract void Write(string text);

        protected void AppendToEnd(string text, LoggerMessageType type)
        {
            if (!FileExists)
                throw new InvalidOperationException();

            try
            {
                File.AppendAllText(PathFile, GetFormattedLoggerText(text, type));
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void CheckFolderExists(bool createFile)
        {
            try
            {
                if (File.Exists(PathFile))
                {
                    FileExists = true;
                }
                else
                {
                    if (createFile)
                    {
                        File.AppendAllText(PathFile,
                                        "File created: " + DateTime.Now.ToString("dd-MM-yyy HH:mm:ss") +
                                            Environment.NewLine + Environment.NewLine +
                                            "Logs" + Environment.NewLine);

                        FileExists = File.Exists(PathFile);
                    }
                }
            }
            
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private string GetFormattedLoggerText(string text, LoggerMessageType type)
        {
            StringBuilder sb = new StringBuilder();

            switch (type)
            {
                case LoggerMessageType.Exception:
                    sb.Append("EXCEPTION");
                    break;

                default:
                    sb.Append("INFO");
                    break;
            }

            sb.Append(": " + text + Environment.NewLine);
            sb.Append("date: " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + Environment.NewLine + Environment.NewLine);

            return sb.ToString();
        }
    }
}