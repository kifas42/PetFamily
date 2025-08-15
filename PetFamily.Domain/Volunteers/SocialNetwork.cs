namespace PetFamily.Domain.Volunteers;

public record SocialNetwork
{
    public SocialNetwork(string name, string url, string personalAccount)
    {
        Name = name;
        Url = url;
        PersonalAccount = personalAccount;
    }

    public string Name { get; }
    public string Url { get; }
    public string PersonalAccount { get; }
}