using Microsoft.Extensions.Configuration;
using Logging.Core;

namespace Logging.Test
{
    [TestFixture]
    public class LoggingLibraryTest
    {
        private ILogger<LoggingLibraryTest> _log;
        private IStore _store;
        private LoggerConfig _loggerConfig;
        //private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            _store = new FileLogger(config);
            _log = new Logger<LoggingLibraryTest>(_store, config);

            _loggerConfig = new LoggerConfig();
            config.Bind("LogSettings", _loggerConfig);
            var filePath = _loggerConfig.FilePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Create(filePath).Close();
        }

        [Test]
        public void LogInfo_Should_Log_Information_Message()
        {
            //Arrange
            _log.LogInfo("Write log information");

            //Act
            Thread.Sleep(3000);
            string contents = File.ReadAllText(_loggerConfig.FilePath);
            var stringExist = contents.Contains("Level: Info", StringComparison.OrdinalIgnoreCase);

            //Assert
            Assert.IsTrue(stringExist);
        }

        [Test]
        public void LogDebug_Should_Log_Debugging_Message()
        {
            //Arrange
            _log.LogDebug("Write log debugging message");

            //Act
            Thread.Sleep(3000);
            string contents = File.ReadAllText(_loggerConfig.FilePath);
            var stringExist = contents.Contains("Level: Debug", StringComparison.OrdinalIgnoreCase);

            //Assert
            Assert.IsTrue(stringExist);
        }

        [Test]
        public void LogWarning_Should_Log_Warning_Message()
        {
            //Arrange
            _log.LogWarning("Write log warning message");

            //Act
            Thread.Sleep(3000);
            string contents = File.ReadAllText(_loggerConfig.FilePath);
            var stringExist = contents.Contains("Level: Warning", StringComparison.OrdinalIgnoreCase);

            //Assert
            Assert.IsTrue(stringExist);
        }

        [Test]
        public void LogError_Should_Log_Error_With_Exception()
        {
            //Arrange
            try
            {
                string text = null;
                var length = text.Length;
            }
            catch (Exception ex)
            {
                _log.LogError("Error Details", ex);
            }

            //Act
            Thread.Sleep(3000);
            string contents = File.ReadAllText(_loggerConfig.FilePath);
            var stringExist = contents.Contains("Exception:", StringComparison.OrdinalIgnoreCase);

            //Assert
            Assert.IsTrue(stringExist);
        }
    }
}