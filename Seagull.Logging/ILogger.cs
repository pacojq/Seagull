namespace Seagull.Logging
{
    public interface ILogger
    {
        void Log(string msg);
        void Log(string msg, params object[] arg);

        void LogWarning(string msg);
        void LogWarning(string msg, params object[] arg);

        void LogError(string msg);
        void LogError(string msg, params object[] arg);
        
        
        void LogDebug(string msg);
        void LogDebug(string msg, params object[] arg);
    }
}