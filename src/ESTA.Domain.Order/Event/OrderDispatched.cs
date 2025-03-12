namespace ESTA.Domain.Order.Event;

public record OrderDispatched : Shared.Base.Event
{
    public Guid Id { get; set; }
    public DateTime DispatchedAtUtc { get; set; }
}
