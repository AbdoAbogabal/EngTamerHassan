namespace EngTamerHassanTask.Application;

public record CreateTicketCommand(Ticket Ticket) : IRequest;