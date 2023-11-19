namespace EngTamerHassanTask.Application;

public class GetTicketsCountHandler : IRequestHandler<GetTicketsCountQuery, int>
{
    private readonly ITicketRepository _repository;

    public GetTicketsCountHandler(ITicketRepository repository) => _repository = repository;

    public async Task<int> Handle(GetTicketsCountQuery request, CancellationToken cancellationToken) =>
        await _repository.ReadTicketsCount();
}