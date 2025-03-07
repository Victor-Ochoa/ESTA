namespace ESTA.Domain.Event;

public record OrderOutForDelivery : Base.Event
{
    public Guid Id { get; set; }
    public DateTime OrderOutForDeliveryAtUtc { get; set; }
}
