using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;


namespace PetFamily.Domain;

public record PersonBio
{
    private PersonBio(
        string name,
        string? middleName,
        string lastName,
        string email,
        string phone
    )
    {
        Name = name;
        MiddleName = middleName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }

    public string Name { get; }
    public string? MiddleName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }

    public static Result<PersonBio, string> Create(
        string name,
        string? middleName,
        string lastName,
        string email,
        string phone)
    {
        if (string.IsNullOrWhiteSpace(name)) return "Name cannot be empty";
        if (string.IsNullOrWhiteSpace(lastName)) return "Lastname cannot be empty";
        if (string.IsNullOrWhiteSpace(email)) return "Email cannot be empty";
        const string emailPattern =
            @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
        if (!Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
        {
            return "Email is not valid";
        }

        const string phonePattern = @"^\+(?:[0-9] ?){6,14}[0-9]$";
        if (!Regex.IsMatch(phone, phonePattern, RegexOptions.IgnoreCase))
        {
            return "Phone is not valid";
        }

        return new PersonBio(name, middleName, lastName, email, phone);
    }
}