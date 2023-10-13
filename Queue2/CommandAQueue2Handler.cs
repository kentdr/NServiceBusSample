namespace Queue2
{
    using Messages;
    using Microsoft.Extensions.Logging;

    public class CommandAQueue2Handler : IHandleMessages<CommandAQueue2>
    {
        readonly ILogger<CommandAQueue2Handler> logger;
        
        public CommandAQueue2Handler(ILogger<CommandAQueue2Handler> logger)
        {
            this.logger = logger;
        }
        public Task Handle(CommandAQueue2 message, IMessageHandlerContext context)
        {
            logger.LogInformation("Received message {MessageCommandId}", message.CommandId);

            return Task.CompletedTask;
        }
    }
}
