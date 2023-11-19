namespace EngTamerHassanTask.Api;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly ISender _sender;

    public TicketsController(ISender sender) => _sender = sender;

    [HttpGet("{page}/{size}")]
    public virtual async Task<IActionResult> Get(int page, int size) => Ok(await _sender.Send(new GetAllTicketQuery(page, size)));

    [HttpGet("Id")]
    public virtual async Task<IActionResult> GetById(Guid id) => Ok(await _sender.Send(new GetTicketByIdQuery(id)));

    [HttpPost]
    public virtual async Task Post(Ticket ticket) => await _sender.Send(new CreateTicketCommand(ticket));

    [HttpPut]
    public virtual async Task Put(Ticket ticket) => await _sender.Send(new UpdateTicketCommand(ticket));

    [HttpDelete("{id}")]
    public virtual async Task Delete(Guid id) => await _sender.Send(new DeleteTicketCommand(id));


    [HttpGet("GetTicketsCount")]
    public async Task<int> GetTicketsCount() => await _sender.Send(new GetTicketsCountQuery());

}