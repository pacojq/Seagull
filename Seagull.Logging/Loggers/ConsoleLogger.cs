using System;

namespace Seagull.Logging.Loggers
{
    public class ConsoleLogger : ILogger
    {
        private readonly object _locker = new object();
        
        private const int WARNING_FLAG = 0;
        private const int ERROR_FLAG = 1;
        private const int DEBUG_FLAG = 2;

        private void ConsolePrint(string msg, ConsoleColor col, int flag = -1)
        {
            lock (_locker)
            {
                var temp = Console.ForegroundColor;
                Console.ForegroundColor = col;

                string strFlag;
                switch (flag)
                {
                    case WARNING_FLAG:
                        strFlag = "WARNING | ";
                        break;
                    case ERROR_FLAG:
                        strFlag = "ERROR   | ";
                        break;
                    case DEBUG_FLAG:
                        strFlag = "DEBUG   | ";
                        break;
                    default:
                        strFlag = "          ";
                        break;
                }

                Console.WriteLine(strFlag + msg);
                Console.ForegroundColor = temp;
            }
        }
        
        
        

        public void Log(string msg)
        {
            ConsolePrint(msg, ConsoleColor.Cyan);
        }

        public void Log(string msg, params object[] arg)
        {
            Log(string.Format(msg, arg));
        }

        
        
        public void LogWarning(string msg)
        {
            ConsolePrint(msg, ConsoleColor.Yellow, WARNING_FLAG);
        }

        public void LogWarning(string msg, params object[] arg)
        {
            LogWarning(string.Format(msg, arg));
        }
        
        
        

        public void LogError(string msg)
        {
            ConsolePrint(msg, ConsoleColor.Red, ERROR_FLAG);
        }

        public void LogError(string msg, params object[] arg)
        {
            LogError(string.Format(msg, arg));
        }
        
        
        
        public void LogDebug(string msg)
        {
#if DEBUG
            ConsolePrint(msg, ConsoleColor.Magenta, DEBUG_FLAG);
#endif
        }

        public void LogDebug(string msg, params object[] arg)
        {
#if DEBUG
            LogDebug(string.Format(msg, arg));
#endif
        }
    }
}