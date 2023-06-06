using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
.ConfigureServices((hostContext, services) =>
{
    services.AddHostedService<MyHostedService>();
})
.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
})
.Build();

await host.RunAsync();
