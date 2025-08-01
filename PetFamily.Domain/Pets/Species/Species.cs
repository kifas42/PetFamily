using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets.Species;

public class Species : Entity<Guid>
{
    public Species(Guid id, string title):base(id)
    {
        Title = title;
    }
    public string Title { get; private set; }
    public IReadOnlyList<Breed> Breeds => _breeds;

    private readonly List<Breed> _breeds = [];

    public Result AddBreed(Breed breed)
    {
        if (_breeds.Contains(breed))
        {
            return Result.Failure("This breed already exist");
        }
        _breeds.Add(breed);
        return Result.Success();
    }

    public Result RemoveBreed(Breed breed)
    {
        if (!_breeds.Contains(breed))
        {
            return Result.Failure("This breed not found");
        }
        _breeds.Remove(breed);
        return Result.Success();
    }
    public Result RemoveBreed(Guid id)
    {
        var breed = _breeds.SingleOrDefault(b => b.Id == id);

        return breed == null ? Result.Failure($"Id {id} not found") : RemoveBreed(breed);
    }

}
