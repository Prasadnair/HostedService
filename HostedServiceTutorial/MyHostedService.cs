using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class MyHostedService : IHostedService, IDisposable
{
    private readonly ILogger<MyHostedService> _logger;
    private Timer _timer;

    public MyHostedService(ILogger<MyHostedService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("MyHostedService is starting.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        _logger.LogInformation("Doing some work...");
        // Perform your background processing or task here
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("MyHostedService is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
