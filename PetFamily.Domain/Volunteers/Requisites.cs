namespace PetFamily.Domain.Volunteers;

public record Requisites
{
    public Requisites(string title, string helpDescription, string bankName, string bankAccount)
    {
        Title = title;
        HelpDescription = helpDescription;
        BankName = bankName;
        BankAccount = bankAccount;
    }
    
    public string Title { get; }
    public string HelpDescription { get; }
    public string BankName { get; }
    public string BankAccount { get; }
    
}
