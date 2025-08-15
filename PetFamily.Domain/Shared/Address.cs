using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record Address
{
    public string Street { get; }
    public string City { get; }
    public string? StateOrProvince { get; }
    public string? PostalCode { get; }
    public string Country { get; }

    public Address(
        string street,
        string city,
        string? stateOrProvince,
        string? postalCode,
        string country)
    {
        Street = street;
        City = city;
        StateOrProvince = stateOrProvince;
        PostalCode = postalCode;
        Country = country;
    }
}