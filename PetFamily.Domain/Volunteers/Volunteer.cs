using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteers;

public class Volunteer : Entity<Guid>
{
    // ef core
    private Volunteer()
    {
    }

    public Volunteer(
        Guid id,
        PersonBio bio,
        string description,
        string experience,
        Requisites requisites
    ) : base(id)
    {
        Bio = bio;
        Description = description;
        Experience = experience;
        Requisites = requisites;
    }

    public PersonBio Bio { get; private set; } = null!;
    public string Description { get; private set; } = string.Empty;
    public string Experience { get; private set; } = string.Empty;
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    public Requisites Requisites { get; private set; } = null!;

    public int GetDomesticatedPetCount() => GetPetCount(PetStatus.HasHome);
    public int GetLookingForHomePetCount() => GetPetCount(PetStatus.NeedHome);
    public int GetReceivingTreatmentPetCount() => GetPetCount(PetStatus.NeedTreatment);

    public Volunteer AddSocialNetwork(SocialNetwork socialNetwork)
    {
        if (_socialNetworks.Contains(socialNetwork)) return this;
        _socialNetworks.Add(socialNetwork);
        return this;
    }

    public IResult RegisterNewPet(Pet pet)
    {
        if (_pets.Contains(pet)) return Result.Failure(("This pet already registered"));
        _pets.Add(pet);
        return Result.Success();
    }

    private readonly List<SocialNetwork> _socialNetworks = [];

    private int GetPetCount(PetStatus status)
    {
        return _pets.Count(pet => pet.Status == status);
    }

    private readonly List<Pet> _pets = [];
}

