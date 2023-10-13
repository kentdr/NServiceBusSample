using System.Text.Json;
using Messages;
using Microsoft.Extensions.Hosting;
using NServiceBus;

Console.WriteLine("Client");

Console.Title = "Client";

var endpointConfiguration = new EndpointConfiguration("Client");

endpointConfiguration.UseSerialization<SystemJsonSerializer>();
var routing = endpointConfiguration.UseTransport(new LearningTransport());

endpointConfiguration.SendFailedMessagesTo("error");
endpointConfiguration.AuditProcessedMessagesTo("audit");

routing.RouteToEndpoint(typeof(CommandAQueue1), "Queue1");

var endpoint = await Endpoint.Start(endpointConfiguration);

await endpoint.Send(new CommandAQueue1());

await endpoint.Stop();
