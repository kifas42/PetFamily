using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;

namespace PetFamily.Domain;

public class Volunteer : Entity<Guid>
{
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

    public PersonBio Bio { get; private set; }
    public string Description { get; private set; }
    public string Experience { get; private set; }
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    public Requisites Requisites { get; private set; }

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

/*
 * Id
ФИО
Email
Общее описание
Опыт в годах
Количество домашних животных, которые смогли найти дом (это должен быть метод, который берёт список животных и считает количество по их статусу)
Количество домашних животных, которые ищут дом в данный момент времени (это должен быть метод, который берёт список животных и считает количество по их статусу)
Количество животных, которые сейчас находятся на лечении (это должен быть метод, который берёт список животных и считает количество по их статусу)
Номер телефона
Социальные сети (список соц. сетей, у каждой социальной сети должна быть ссылка и название), поэтому нужно сделать отдельный класс для социальной сети. Это должен быть Value Object.
Реквизиты для помощи (у каждого реквизита будет название и описание, как сделать перевод), поэтому нужно сделать отдельный класс для реквизита. Это должен быть Value Object.
Список домашних животных, которыми владеет волонтёр.

*/