namespace PetFamily.Domain.Pets;

public record HealthInfo
{
    public HealthInfo(HealthRating rating, string description)
    {
        HealthRating = rating;
        Description = description;
    }

    public HealthRating HealthRating { get; }
    public string Description { get; } = string.Empty;
}

public enum HealthRating
{
    Serios,
    Bad,
    Satisfactory,
    Good
}