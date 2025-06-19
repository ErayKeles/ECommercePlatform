namespace NotificationService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRabbitMqListener _listener;

        public Worker(ILogger<Worker> logger, IRabbitMqListener listener)
        {
            _logger = logger;
            _listener = listener;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("NotificationService baþlatýldý: {time}", DateTimeOffset.Now);
            _listener.StartListening(); // RabbitMQ kuyruk dinlemeye baþlar
            return Task.CompletedTask;
        }
    }
}
