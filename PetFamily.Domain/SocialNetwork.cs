namespace PetFamily.Domain;

public record SocialNetwork
{
    public SocialNetwork(string name, string link, string personalAccount)
    {
        Name = name;
        Link = link;
        PersonalAccount = personalAccount;
    }

    public string Name { get; }
    public string Link { get; }
    public string PersonalAccount { get; }
}