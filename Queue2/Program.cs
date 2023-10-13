using Microsoft.Extensions.Hosting;
using NServiceBus;

Console.WriteLine("Queue2");
Console.Title = "Queue2";
await CreateHostBuilder(args).RunConsoleAsync();

IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .UseNServiceBus(context =>
        {
            var endpointConfiguration = new EndpointConfiguration("Queue2");

            endpointConfiguration.UseSerialization<SystemJsonSerializer>();
            endpointConfiguration.EnableInstallers();
            
            endpointConfiguration.UseTransport(new LearningTransport());
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.AuditProcessedMessagesTo("audit");
            
            return endpointConfiguration;
        });
}
