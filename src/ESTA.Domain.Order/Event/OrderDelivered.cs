namespace ESTA.Domain.Order.Event;

public record OrderDelivered : Shared.Base.Event
{
    public Guid Id { get; set; }
    public DateTime DeliveredAtUtc { get; set; }
}
