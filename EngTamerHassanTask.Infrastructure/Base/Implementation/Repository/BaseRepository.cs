namespace EngTamerHassanTask.Infrastructure;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected DbSet<TEntity> dbSet;
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        dbSet = context.Set<TEntity>();
    }
    public virtual async Task<List<TEntity>> Get(int page, int size) => await dbSet.Skip((page - 1) * size).Take(size).ToListAsync();

    public virtual async Task<TEntity?> GetById(Guid id) => await dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public virtual async Task Create(TEntity obj)
    {
        try
        {
            obj.CheckIsNull();

            dbSet.Add(obj);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task Update(TEntity obj)
    {
        try
        {
            obj.CheckIsNull();

            dbSet.Update(obj);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task Remove(Guid id)
    {
        try
        {
            var entityFromDb = await dbSet.FirstOrDefaultAsync(x => x.Id == id) ??
                throw new ArgumentNullException($"{typeof(TEntity).Name} with id: {id} is not found");
                
            dbSet.Remove(entityFromDb);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public virtual async Task CreateBulk(List<TEntity> entities)
    {
        dbSet.AddRange(entities);

        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateBulk(List<TEntity> entities)
    {
        dbSet.UpdateRange(entities);

        await _context.SaveChangesAsync();
    }

    public virtual async Task RemoveBulk(List<TEntity> entities)
    {
        //dbSet.RemoveRange(entities);
        List<Guid> ids = entities.Select(e => e.Id).ToList();
        await dbSet.Where(e => ids.Contains(e.Id)).ExecuteDeleteAsync();

        await _context.SaveChangesAsync();
    }
}