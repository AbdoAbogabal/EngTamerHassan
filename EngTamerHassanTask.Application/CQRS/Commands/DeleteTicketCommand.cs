namespace EngTamerHassanTask.Application;

public record DeleteTicketCommand(Guid Id) : IRequest;