namespace ESTA.Domain.Shared.Base;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
}
