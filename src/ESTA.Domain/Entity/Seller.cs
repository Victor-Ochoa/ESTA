using ESTA.Domain.ValueObject;

namespace ESTA.Domain.Entity;

public class Seller : Base.Entity
{
    public string OpenId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Address Address { get; set; } = new Address();

}
