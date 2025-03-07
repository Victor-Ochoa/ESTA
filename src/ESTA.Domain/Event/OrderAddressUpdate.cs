using ESTA.Domain.ValueObject;

namespace ESTA.Domain.Event;

public record OrderAddressUpdate : Base.Event
{
    public Guid Id { get; set; }
    public Address DeliveryAddress { get; set; }
}
