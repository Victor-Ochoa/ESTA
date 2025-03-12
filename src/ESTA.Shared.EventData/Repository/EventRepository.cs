using ESTA.Domain.Shared.Base;
using ESTA.Domain.Shared.Contract.Repository;
using Marten;
using System.Linq.Expressions;

namespace ESTA.Shared.EventData.Repository;

public class EventRepository<IEntity>(IQuerySession session, IDocumentStore store) : IRepositoryEvent<IEntity> where IEntity : Entity
{
    public async Task AddEvent(Event entity, Guid id)
    {
        await using var session = store.LightweightSession();

        session.Events.Append(id, entity);

        await session.SaveChangesAsync();
    }

    public async Task<Event> Create(Event entity, Guid id)
    {
        await using var session = store.LightweightSession();

        session.Events.StartStream<IEntity>(id, entity);

        await session.SaveChangesAsync();

        return entity;
    }

    public async Task<IEntity> Get(Guid id) => await session.LoadAsync<IEntity>(id);

    public async Task<IReadOnlyList<IEntity>> GetAll(Expression<Func<IEntity, bool>>? predicate = null) => await session.Query<IEntity>().ToListAsync();
}
