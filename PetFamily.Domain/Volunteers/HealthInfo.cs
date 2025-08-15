namespace PetFamily.Domain.Volunteers;

public record HealthInfo
{
    public HealthInfo(HealthRating healthRating, string description)
    {
        HealthRating = healthRating;
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