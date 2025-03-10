using ESTA.Domain.ValueObject;

namespace ESTA.OrderApi.Request;

public record DeliveryAddressUpdateRequest
{
    public Address DeliveryAddress { get; set; }
}
