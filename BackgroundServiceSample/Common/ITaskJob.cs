using System.Collections.Concurrent;

namespace BackgroundServiceSample.Common
{
    public interface ITaskJob
    {
        ConcurrentQueue<string> Queue { get; set; }
    }
}
