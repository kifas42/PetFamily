namespace PetFamily.Domain;

public record Requisites(string Title, string HelpDescription, string BankName, string BankAccount)
{
    public Guid Id { get; } = Guid.NewGuid();
}
