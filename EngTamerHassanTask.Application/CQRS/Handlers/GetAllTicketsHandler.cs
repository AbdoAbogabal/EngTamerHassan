namespace EngTamerHassanTask.Application;

public class GetAllTicketsHandler : IRequestHandler<GetAllTicketQuery, IEnumerable<Ticket>>
{
    private readonly ITicketRepository _repository;

    public GetAllTicketsHandler(ITicketRepository repository) => _repository = repository;

    public async Task<IEnumerable<Ticket>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken) =>
           await _repository.Get(request.Page, request.Size);
}