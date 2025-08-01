using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets.Species;

namespace PetFamily.Domain.Pets;

public class Pet : Entity<Guid>
{
    private Pet(
        Guid id,
        string name,
        string description,
        PetType petType,
        string color,
        string address,
        double weight,
        double height,
        string phoneNumber,
        string gender,
        bool isSterilized,
        DateOnly dateOfBirth,
        bool isVaccinated,
        PetStatus status
        ):base(id)
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

        Health = new HealthInfo()
        {
            HealthRating = HealthRating.Good,
            Description = "feel good"
        };

    }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public PetType PetType { get; private set; }
    public string Color { get; private set; }
    public HealthInfo Health { get; private set; }
    public string Address { get; private set; }

    public double WeightKilogram { get; private set; }
    public double HeightCentimeters { get; private set; }
    public string OwnerPhoneNumber { get; private set; }
    public string Gender { get; private set; }
    public bool IsSterilized { get; private set; }

    public DateOnly DateOfBirth { get; private set; }
    public bool IsVaccinated { get; private set; }
    public PetStatus Status { get; private set; }
    public DateTime DateOfRegistration { get; private set; }
    public IReadOnlyList<Requisites> Requisites => _requisites;

    private List<Requisites> _requisites = [];


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
    public IResult RemoveRequisite(Guid id)
    {
        var req = _requisites.SingleOrDefault(r => r.Id == id);

        return req == null ? Result.Failure($"Id {id} not found") : RemoveRequisite(req);
    }
}