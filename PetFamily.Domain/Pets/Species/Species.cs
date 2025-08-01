using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets.Species;

public record Species
{
    public Species(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
    }
    public Guid Id { get; }
    public string Title { get; }
    public IReadOnlyList<Breed> Breeds => _breeds;

    private readonly List<Breed> _breeds = [];

    public IResult AddBreed(Breed breed)
    {
        if (_breeds.Contains(breed))
        {
            return Result.Failure("This breed already exist");
        }
        _breeds.Add(breed);
        return Result.Success();
    }

    public IResult RemoveBreed(Breed breed)
    {
        if (!_breeds.Contains(breed))
        {
            return Result.Failure("This breed not found");
        }
        _breeds.Remove(breed);
        return Result.Success();
    }
    public IResult RemoveBreed(Guid id)
    {
        var breed = _breeds.SingleOrDefault(b => b.Id == id);

        return breed == null ? Result.Failure($"Id {id} not found") : RemoveBreed(breed);
    }

}
