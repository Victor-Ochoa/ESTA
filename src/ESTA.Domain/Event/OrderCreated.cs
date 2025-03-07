using ESTA.Domain.ValueObject;

namespace ESTA.Domain.Event;

public record OrderCreated : Base.Event
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public Guid Seller { get; set; }

    public IList<Guid> Products { get; set; } = new List<Guid>();

    public Address DeliveryAddress { get; set; }
}
