using ESTA.Domain.Shared.ValueObject;

namespace ESTA.OrderApi.Request;

public record DeliveryAddressUpdateRequest
{
    public Address DeliveryAddress { get; set; }
}
