using Seagull.Logging.Loggers;

namespace Seagull.Logging
{
    public class Logger : ILogger
    {

        private static Logger _instance;
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Logger();
                return _instance;
            }
        }
        
        
        private readonly ILogger _logger;

        private Logger()
        {
            _logger = new ConsoleLogger();
        }
        
        
        
        
        
        public void Log(string msg)
        {
            _logger.Log(msg);
        }

        public void Log(string msg, params object[] arg)
        {
            _logger.Log(msg, arg);
        }

        public void LogWarning(string msg)
        {
            _logger.LogWarning(msg);
        }

        public void LogWarning(string msg, params object[] arg)
        {
            _logger.LogWarning(msg, arg);
        }

        public void LogError(string msg)
        {
            _logger.LogError(msg);
        }

        public void LogError(string msg, params object[] arg)
        {
            _logger.LogError(msg, arg);
        }

        public void LogDebug(string msg)
        {
            _logger.LogDebug(msg);
        }

        public void LogDebug(string msg, params object[] arg)
        {
            _logger.LogDebug(msg, arg);
        }
    }
}