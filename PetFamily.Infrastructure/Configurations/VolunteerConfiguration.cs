using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        builder.HasKey(v => v.Id).HasName("pk_volunteers");
        builder.Property(v => v.Id).HasColumnName("id");
        builder.ComplexProperty(v => v.Bio, bb =>
        {
            bb.Property(b => b.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            bb.Property(b => b.MiddleName)
                .HasColumnName("middle_name")
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            bb.Property(b => b.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            bb.Property(b => b.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            bb.Property(b => b.Phone)
                .HasColumnName("phone")
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        });
        builder.Property(b => b.Description)
            .HasColumnName("description")
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        builder.Property(b => b.Experience)
            .HasColumnName("experience")
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        builder.OwnsMany(b => b.SocialNetworks, bs =>
        {
            bs.ToJson("social_networks");
            bs.Property(s => s.Name)
                .HasColumnName("social_network_name")
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            bs.Property(s => s.Url)
                .HasColumnName("social_network_url")
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            bs.Property(s => s.PersonalAccount)
                .HasColumnName("social_network_account")
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        });
        builder.ComplexProperty(v => v.Requisites, rb =>
        {
            rb.Property(r => r.Title)
                .HasColumnName("requisite_title")
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            rb.Property(r => r.HelpDescription)
                .HasColumnName("help_description")
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
            rb.Property(r => r.BankName)
                .HasColumnName("bank_name")
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            rb.Property(r => r.BankAccount)
                .HasColumnName("bank_account")
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        });
    }
}