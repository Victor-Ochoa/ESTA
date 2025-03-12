using ESTA.Domain.Shared.Base;
using System.Linq.Expressions;

namespace ESTA.Domain.Shared.Contract.Repository;

public interface IRepositoryEvent<IEntity> where IEntity : Entity
{
    Task<IReadOnlyList<IEntity>> GetAll(Expression<Func<IEntity, bool>>? predicate = null);
    Task<IEntity> Get(Guid id);
    Task<Event> Create(Event entity, Guid id);
    Task AddEvent(Event entity, Guid id);
}
