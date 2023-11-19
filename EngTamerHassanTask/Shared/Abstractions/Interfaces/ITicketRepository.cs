namespace EngTamerHassanTask.Domain;

public interface ITicketRepository : IBaseRepository<Ticket>
{
    Task<int> ReadTicketsCount();
}