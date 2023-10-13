namespace Queue1;
using Messages;
using Microsoft.Extensions.Logging;

public class CommandAQueue1Handler : IHandleMessages<CommandAQueue1>
    {
        readonly ILogger<CommandAQueue1Handler> logger;
        
        public CommandAQueue1Handler(ILogger<CommandAQueue1Handler> logger)
        {
            this.logger = logger;
        }
        
        public async Task Handle(CommandAQueue1 message, IMessageHandlerContext context)
        {
            var commandAQueue2 = new CommandAQueue2()
            {
                CommandId = Guid.NewGuid().ToString()
            };
            
            logger.LogInformation("Sending command id {CommandId} to Queue2", commandAQueue2.CommandId);
            
            await context.Send(commandAQueue2);
        }
    }

