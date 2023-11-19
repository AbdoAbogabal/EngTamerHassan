namespace EngTamerHassanTask.Domain;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task Create(TEntity obj);
    Task CreateBulk(List<TEntity> entities);
    Task<List<TEntity>> Get(int page, int size);
    Task<TEntity?> GetById(Guid id);
    Task Remove(Guid id);
    Task RemoveBulk(List<TEntity> entities);
    Task Update(TEntity obj);
    Task UpdateBulk(List<TEntity> entities);
}