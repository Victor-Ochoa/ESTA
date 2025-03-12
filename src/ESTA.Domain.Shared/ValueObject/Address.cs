namespace ESTA.Domain.Shared.ValueObject;

public readonly record struct Address
{
    public Address() { }

    public string Street { get; init; } = string.Empty;
    public string Number { get; init; } = string.Empty;
    public string Complement { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
    public string ZipCode { get; init; } = string.Empty;
}
