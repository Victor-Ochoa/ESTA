using ESTA.Domain.Shared.ValueObject;

namespace ESTA.Domain.Order.Event;

public record OrderAddressUpdate : Shared.Base.Event
{
    public Guid Id { get; set; }
    public Address DeliveryAddress { get; set; }
}
