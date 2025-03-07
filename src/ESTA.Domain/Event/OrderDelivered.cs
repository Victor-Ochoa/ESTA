namespace ESTA.Domain.Event;

public record OrderDelivered : Base.Event
{
    public Guid Id { get; set; }
    public DateTime DeliveredAtUtc { get; set; }
}
