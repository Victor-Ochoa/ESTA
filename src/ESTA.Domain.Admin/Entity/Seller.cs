using ESTA.Domain.Shared.ValueObject;

namespace ESTA.Domain.Entity;

public class Seller : Shared.Base.Entity
{
    public string OpenId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Address Address { get; set; } = new Address();

}
