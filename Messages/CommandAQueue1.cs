namespace Messages;

using NServiceBus;

public class CommandAQueue1 : ICommand
{
    public string CommandId { get; set; }
}
