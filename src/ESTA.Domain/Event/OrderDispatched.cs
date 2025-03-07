namespace ESTA.Domain.Event;

public record OrderDispatched : Base.Event
{
    public Guid Id { get; set; }
    public DateTime DispatchedAtUtc { get; set; }
}
