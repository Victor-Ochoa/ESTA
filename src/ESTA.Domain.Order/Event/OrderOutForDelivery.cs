namespace ESTA.Domain.Order.Event;

public record OrderOutForDelivery : Shared.Base.Event
{
    public Guid Id { get; set; }
    public DateTime OrderOutForDeliveryAtUtc { get; set; }
}
