using ESTA.Domain.Shared.Base;
using ESTA.Domain.Shared.Contract.Repository;
using ESTA.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ESTA.Shared.Data.Repository;

public class EntityRepository<IEntity>(EstaDbContext dbContext) : IRepositoryEntity<IEntity> where IEntity : Entity
{
    public async Task<IEntity> Create(IEntity entity)
    {
        await dbContext.Set<IEntity>().AddAsync(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var entity = await dbContext.Set<IEntity>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) return false;

        dbContext.Set<IEntity>().Remove(entity);

        await dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<IEntity> Get(Guid id) => await dbContext.Set<IEntity>().FindAsync(id);

    public async Task<IEntity> Get(Expression<Func<IEntity, bool>> predicate) => await dbContext.Set<IEntity>().FirstOrDefaultAsync(predicate);

    public async Task<IList<IEntity>> GetAll(Expression<Func<IEntity, bool>>? predicate = null) => predicate == null
            ? await dbContext.Set<IEntity>().ToListAsync()
            : (IList<IEntity>)await dbContext.Set<IEntity>().Where(predicate).ToListAsync();

    public async Task<IEntity> Update(IEntity entity)
    {
        dbContext.Set<IEntity>().Update(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> Exist(Guid id) => await dbContext.Set<IEntity>().AnyAsync(e => e.Id == id);
}
