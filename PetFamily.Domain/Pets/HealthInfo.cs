namespace PetFamily.Domain.Pets;

public record HealthInfo
{
    public HealthRating HealthRating { get; set; }
    public string Description { get; set; } = string.Empty;

}

public enum HealthRating
{
    Serios,
    Bad,
    Satisfactory,
    Good
}
