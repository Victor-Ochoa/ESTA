using System.Linq.Expressions;

namespace ESTA.Domain.Contract.Repository;

public interface IRepositoryEntity<IEntity> where IEntity : Base.Entity
{
    Task<IList<IEntity>> GetAll(Expression<Func<IEntity, bool>>? predicate = null);
    Task<IEntity> Get(Guid id);
    Task<IEntity> Get(Expression<Func<IEntity, bool>> predicate);
    Task<IEntity> Create(IEntity entity);
    Task<IEntity> Update(IEntity entity);
    Task<bool> Delete(Guid id);
    Task<bool> Exist(Guid id);
}
