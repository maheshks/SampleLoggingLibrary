/*
This class to collect and format data and invoke store method to write the data
 */

using Microsoft.Extensions.Configuration;
using System.Text;

namespace Logging.Core
{
    public class Logger<T> : ILogger<T>
    {
        private IStore _store;

        private readonly LoggerConfig _loggerConfig;

        public Logger(IStore store, IConfiguration configuration)
        {
            _store = store;
            _loggerConfig = new LoggerConfig();
            configuration.Bind("LogSettings", _loggerConfig);
        }

        /// <summary>
        /// This method collects the data, format it and invoke store method to write the data
        /// </summary>
        /// <param name="level">Log level is Info, Debug, Warning, Error</param>
        /// <param name="message">Log message which gets logged</param>
        /// <param name="exception">Stack trace in case of any error</param>
        public void Log(LogLevel level, string message, Exception? exception = null)
        {
            if (!_loggerConfig.IsEnabled) return;

            if (_loggerConfig.MinimumLogLevel > level) return;

            //Format the log
            var sb = new StringBuilder();
            sb.AppendLine("******************************************************");
            sb.Append($"ID: {Guid.NewGuid()}");
            sb.AppendLine();
            sb.Append($"Type: {typeof(T).Name}");
            sb.AppendLine();
            sb.Append($"Datetime: {DateTime.UtcNow}");
            sb.AppendLine();
            sb.Append($"Level: {level}");
            sb.AppendLine();
            sb.Append($"Message: {message}");
            sb.AppendLine();

            if (exception != null)
                sb.Append($"Exception: ${exception}");

            Task.Run(async () =>
            {
                await _store.Write(sb.ToString());
            });
        }
    }
}
