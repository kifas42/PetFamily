using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets.Species;

public class Breed
{
    private Breed(string title)
    {
        Title = title;
        Id = Guid.NewGuid();
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; }

    public static Result<Breed, string> CreateBreed(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return "Title could not be empty or white spaces";
        }

        return new Breed(title);
    }
}
