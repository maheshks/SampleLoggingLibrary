/*
 Interface to extend the logger library to write into different logging media
 */
namespace Logging.Core
{
    public interface IStore
    {
        public Task Write(string data);
    }
}
