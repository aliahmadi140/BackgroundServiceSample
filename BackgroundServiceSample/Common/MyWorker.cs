namespace BackgroundServiceSample.Common
{
    public class MyWorker : BackgroundService
    {
        private readonly ITaskJob _taskJob;
        private readonly ILogger<MyWorker> _logger;
        public MyWorker(ITaskJob taskJob, ILogger<MyWorker> logger)
        {
            _logger = logger;
            _taskJob = taskJob;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                    if (_taskJob.Queue.Any())
                    {
                        

                        var taskList = new List<Task>();
                        _logger.LogInformation($"message queued: ", _taskJob.Queue.Count);

                        for (int i = 0; i < _taskJob.Queue.Count; i++)
                        {
                            var success = _taskJob.Queue.TryDequeue(out var msg);
                            if (success)
                            {
                                taskList.Add(LogMessage(msg));
                            }
                        }
                        await Task.WhenAll(taskList);

                        
                    }
                    await Task.Delay(5000);
                
            }
        }
        private async Task LogMessage(string message)
        {
            await Task.Delay(1000);
            _logger.LogInformation(message);
        }
    }
}
