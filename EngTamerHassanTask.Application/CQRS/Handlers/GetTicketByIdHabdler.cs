namespace EngTamerHassanTask.Application;

public class GetTicketByIdHabdler : IRequestHandler<GetTicketByIdQuery, Ticket>
{
    private readonly ITicketRepository _repository;

    public GetTicketByIdHabdler(ITicketRepository repository) => _repository = repository;

    public async Task<Ticket> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken) =>
           await _repository.GetById(request.Id) ?? new();
}