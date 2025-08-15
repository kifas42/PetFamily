using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        builder.HasKey(p => p.Id).HasName("pk_pets");
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Name).IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("name");
        builder.Property(p => p.Description).IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
            .HasColumnName("description");
        builder.ComplexProperty(p => p.PetType,
            pb =>
            {
                pb.Property(pt => pt.BreedId).IsRequired().HasColumnName("breed_id");
                pb.Property(pt => pt.SpeciesId).IsRequired().HasColumnName("species_id");
            });
        builder.ComplexProperty(p => p.Health, hb =>
        {
            hb.Property(h => h.Description)
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .IsRequired()
                .HasColumnName("health_description");
            hb.Property(h => h.HealthRating)
                .IsRequired()
                .HasColumnName("health_rating");
        });
        builder.Property(p => p.Color)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("color");
        builder.ComplexProperty(p => p.Address, ab =>
        {
            ab.Property(a => a.Street)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("street");
            ab.Property(a => a.City)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("city");
            ab.Property(a => a.StateOrProvince)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .IsRequired(false)
                .HasColumnName("state_or_province");
            ab.Property(a => a.PostalCode)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("postal_code")
                .IsRequired(false);
            ab.Property(a => a.Country)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("country");
        });
        builder.Property(p => p.WeightKilogram)
            .IsRequired()
            .HasColumnName("weight_kg");
        builder.Property(p => p.HeightCentimeters)
            .IsRequired()
            .HasColumnName("height_centimeters");
        builder.Property(p => p.OwnerPhoneNumber)
            .IsRequired()
            .HasColumnName("owner_phone_number");
        builder.Property(p => p.Gender)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("gender");
        builder.Property(p => p.IsSterilized)
            .IsRequired()
            .HasColumnName("is_sterilized");
        builder.Property(p => p.DateOfBirth)
            .IsRequired()
            .HasColumnName("date_of_birth");
        builder.Property(p => p.IsVaccinated)
            .IsRequired()
            .HasColumnName("is_vaccinated");
        builder.Property(p => p.Status)
            .IsRequired()
            .HasColumnName("status");
        builder.Property(p => p.DateOfRegistration)
            .IsRequired()
            .HasColumnName("date_of_registration");
        builder.OwnsMany(p => p.Requisites, rb =>
        {
            rb.ToJson("requisites");
            rb.Property(r => r.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            rb.Property(r => r.BankAccount)
                .IsRequired()
                .HasColumnName("bank_account")
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            rb.Property(r => r.BankName)
                .IsRequired()
                .HasColumnName("bank_name")
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            rb.Property(r => r.HelpDescription)
                .IsRequired()
                .HasColumnName("help_description")
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        });
    }
}