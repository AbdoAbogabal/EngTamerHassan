namespace EngTamerHassanTask.Application;

public class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand>
{
    private readonly ITicketRepository _repository;

    public UpdateTicketHandler(ITicketRepository repository) => _repository = repository;

    public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        await _repository.Update(request.Ticket);

        return await Task.FromResult(Unit.Value);
    }
}