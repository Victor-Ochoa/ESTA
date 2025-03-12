using ESTA.Domain.Shared.Base;
using System.Linq.Expressions;

namespace ESTA.Domain.Shared.Contract.Repository;

public interface IRepositoryEntity<IEntity> where IEntity : Entity
{
    Task<IList<IEntity>> GetAll(Expression<Func<IEntity, bool>>? predicate = null);
    Task<IEntity> Get(Guid id);
    Task<IEntity> Get(Expression<Func<IEntity, bool>> predicate);
    Task<IEntity> Create(IEntity entity);
    Task<IEntity> Update(IEntity entity);
    Task<bool> Delete(Guid id);
    Task<bool> Exist(Guid id);
}
