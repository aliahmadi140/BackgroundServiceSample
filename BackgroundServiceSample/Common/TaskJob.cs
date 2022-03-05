using System.Collections.Concurrent;

namespace BackgroundServiceSample.Common
{
    public class TaskJob : ITaskJob
    {
        public TaskJob()
        {
            Queue=new ConcurrentQueue<string>();
        }
        public ConcurrentQueue<string> Queue { get; set; }
    }
}
