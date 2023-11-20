/*
 This class is to write the log message into text file
 */

using Microsoft.Extensions.Configuration;

namespace Logging.Core
{
    public class FileLogger : IStore
    {
        private readonly LoggerConfig _loggerConfig;

        public FileLogger(IConfiguration configuration)
        {
            _loggerConfig = new LoggerConfig();
            configuration.Bind("LogSettings", _loggerConfig);
        }

        /// <summary>
        /// This is to write log message into the text file
        /// </summary>
        /// <param name="data">Log message</param>
        /// <returns></returns>
        public async Task Write(string data)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(_loggerConfig.FilePath))
                {
                    await sw.WriteLineAsync(data);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
