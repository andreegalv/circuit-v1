using System;

namespace WEBComputadora.View.Utils.Loggers
{
    public class ExceptionLogger : BaseLogger
    {
        public override void Write(string text)
        {
            AppendToEnd(text, LoggerMessageType.Exception);
        }

        public static void WriteLog(string text)
        {
            new ExceptionLogger().Write(text);
        }
        public static void WriteLog(string exceptionName, Exception e)
        {
            new ExceptionLogger().Write($"({exceptionName}) {e.Message + Environment.NewLine + e.StackTrace}");
        }
    }
}