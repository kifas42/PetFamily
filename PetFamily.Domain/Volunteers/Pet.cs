using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public class Pet : Entity<Guid>
{
    // ef core
    private Pet(Guid id) : base(id)
    {
    }

    private Pet(
        Guid id,
        string name,
        string description,
        PetType petType,
        string color,
        Address address,
        double weight,
        double height,
        string phoneNumber,
        string gender,
        bool isSterilized,
        DateOnly dateOfBirth,
        bool isVaccinated,
        PetStatus status
    ) : base(id)
    {
        //Id = id;
        Name = name;
        Description = description;
        PetType = petType;
        Color = color;
        Address = address;
        WeightKilogram = weight;
        HeightCentimeters = height;
        OwnerPhoneNumber = phoneNumber;
        Gender = gender;
        IsSterilized = isSterilized;
        DateOfBirth = dateOfBirth;
        IsVaccinated = isVaccinated;
        Status = status;
        DateOfRegistration = DateTime.Now;

        Health = new HealthInfo(HealthRating.Good, "feel good");
    }

    public string Color { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public PetType PetType { get; private set; } = null!;
    public HealthInfo Health { get; private set; } = null!;
    public Address Address { get; private set; } = null!;

    public double WeightKilogram { get; private set; }
    public double HeightCentimeters { get; private set; }
    public string OwnerPhoneNumber { get; private set; } = string.Empty;
    public string Gender { get; private set; } = string.Empty;
    public bool IsSterilized { get; private set; }

    public DateOnly DateOfBirth { get; private set; }
    public bool IsVaccinated { get; private set; }
    public PetStatus Status { get; private set; }
    public DateTime DateOfRegistration { get; private set; }
    public IReadOnlyList<Requisites> Requisites => _requisites;

    private readonly List<Requisites> _requisites = [];


    public IResult AddRequisite(Requisites requisite)
    {
        if (_requisites.Contains(requisite))
        {
            return Result.Failure("Requisite already exist");
        }

        _requisites.Add(requisite);
        return Result.Success();
    }

    public IResult RemoveRequisite(Requisites requisite)
    {
        if (!_requisites.Contains(requisite))
        {
            return Result.Failure("Requisite not found");
        }

        _requisites.Remove(requisite);
        return Result.Success();
    }
}