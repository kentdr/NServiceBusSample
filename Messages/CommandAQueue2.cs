namespace Messages;

using NServiceBus;

    public class CommandAQueue2 : ICommand
    {
        public string CommandId { get; set; }
    }

