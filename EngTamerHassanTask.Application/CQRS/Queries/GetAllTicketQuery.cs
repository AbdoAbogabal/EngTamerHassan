namespace EngTamerHassanTask.Application;

public record GetAllTicketQuery(int Page, int Size) : IRequest<IEnumerable<Ticket>>;