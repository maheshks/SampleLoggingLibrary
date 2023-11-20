namespace Logging.Core
{
    public class LoggerConfig
    {

        public LogLevel MinimumLogLevel { get; set; }
        public bool IsEnabled { get; set; }
        public string FilePath { get; set; }
    }

    public enum LogLevel
    {
        Info,
        Debug,
        Warning,
        Error
    }
}
