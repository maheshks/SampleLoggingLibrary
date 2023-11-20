namespace Logging.Core
{
    public static class LoggerExtension
    {
        public static void LogInfo<T>(this ILogger<T> logObj, string message)
        {
            logObj.Log(LogLevel.Info, message);
        }

        public static void LogDebug<T>(this ILogger<T> logObj, string message, Exception? exception = null)
        {
            logObj.Log(LogLevel.Debug, message);
        }

        public static void LogWarning<T>(this ILogger<T> logObj, string message, Exception? exception = null)
        {
            logObj.Log(LogLevel.Warning, message);
        }

        public static void LogError<T>(this ILogger<T> logObj, string message, Exception exception)
        {
            logObj.Log(LogLevel.Error, message, exception);
        }
    }
}
