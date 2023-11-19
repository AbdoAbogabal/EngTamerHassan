namespace EngTamerHassanTask.Infrastructure;

public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IHostingEnvironment _hostingEnvironment;

    public TicketRepository(ApplicationDbContext context, IHostingEnvironment hostingEnvironment) : base(context)
    {
        _context = context;
        _hostingEnvironment = hostingEnvironment;
    }

    public async Task<int> ReadTicketsCount() => await _context.Set<Ticket>().CountAsync();

    public override async Task Create(Ticket obj)
    {
        obj.CreationDate = _hostingEnvironment.EnvironmentName.Equals("Development") ? DateTime.Now : DateTime.UtcNow;

        await base.Create(obj);
    }
}