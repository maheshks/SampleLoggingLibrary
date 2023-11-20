
namespace Logging.Core
{
    public interface ILogger<T>
    {
         public void Log(LogLevel level, string message, Exception? exception = null);
    }
}
