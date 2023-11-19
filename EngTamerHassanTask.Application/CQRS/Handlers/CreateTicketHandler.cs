namespace EngTamerHassanTask.Application;

public class CreateTicketHandler : IRequestHandler<CreateTicketCommand>
{
    private readonly ITicketRepository _repository;

    public CreateTicketHandler(ITicketRepository repository) => _repository = repository;

    public async Task<Unit> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        await _repository.Create(request.Ticket);

        return await Task.FromResult(Unit.Value);
    }
}