namespace EngTamerHassanTask.Application;

public record UpdateTicketCommand(Ticket Ticket) : IRequest;