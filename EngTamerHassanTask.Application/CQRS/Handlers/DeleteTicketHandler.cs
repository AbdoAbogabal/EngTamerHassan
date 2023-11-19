namespace EngTamerHassanTask.Application;

public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand>
{
    private readonly ITicketRepository _repository;

    public DeleteTicketHandler(ITicketRepository repository) => _repository = repository;

    public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        await _repository.Remove(request.Id);

        return await Task.FromResult(Unit.Value);
    }
}