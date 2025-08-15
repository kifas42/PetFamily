using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared;

public record NotEmptyString
{
    private NotEmptyString(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<NotEmptyString, string> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return "String cannot be empty";
        return new NotEmptyString(value.Trim());
    }
}