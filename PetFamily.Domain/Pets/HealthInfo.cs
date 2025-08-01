namespace PetFamily.Domain.Pets;

public record HealthInfo
{
    public HealthInfo(HealthRating rating, string description)
    {
        HealthRating = rating;
        Description = description;
    }

    public HealthRating HealthRating { get; private set; }
    public string Description { get; private set; } = string.Empty;
}

public enum HealthRating
{
    Serios,
    Bad,
    Satisfactory,
    Good
}