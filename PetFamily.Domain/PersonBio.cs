namespace PetFamily.Domain;

public record PersonBio(
    string Name,
    string MiddleName,
    string LastName,
    string Email,
    string Phone
);