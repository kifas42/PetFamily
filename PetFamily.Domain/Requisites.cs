namespace PetFamily.Domain;

public record Requisites
{
    public Requisites(string title, string helpDescription, string bankName, string bankAccount)
    {
        Title = title;
        HelpDescription = helpDescription;
        BankName = bankName;
        BankAccount = bankAccount;
    }
    
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; }
    public string HelpDescription { get; }
    public string BankName { get; }
    public string BankAccount { get; }
    
}
