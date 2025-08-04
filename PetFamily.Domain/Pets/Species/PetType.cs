namespace PetFamily.Domain.Pets.Species;

public record PetType
{
    public PetType(Guid speciesId, Guid breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }
    public Guid SpeciesId {get;}
    public Guid BreedId { get; }
}