using System.Text.Json;
using Messages;
using Microsoft.Extensions.Hosting;
using NServiceBus;

Console.WriteLine("Queue1");

Console.Title = "Queue1";

await CreateHostBuilder(args).RunConsoleAsync();


IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .UseNServiceBus(context =>
        {
            var endpointConfiguration = new EndpointConfiguration("Queue1");

            endpointConfiguration.UseSerialization<SystemJsonSerializer>();
            endpointConfiguration.EnableInstallers();
            
            var routing = endpointConfiguration.UseTransport(new LearningTransport());

            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.AuditProcessedMessagesTo("audit");
            
            routing.RouteToEndpoint(typeof(CommandAQueue2), "Queue2");
            
            return endpointConfiguration;
        });
}