namespace EngTamerHassanTask.Application;

public record GetTicketByIdQuery(Guid Id) : IRequest<Ticket>;