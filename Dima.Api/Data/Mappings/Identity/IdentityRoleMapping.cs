using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings.Identity;

public class IdentityRoleMapping 
    : IEntityTypeConfiguration<IdentityRole<long>> 
{
    public void Configure(EntityTypeBuilder<IdentityRole<long>> builder)
    {
        builder.ToTable("IdentiyUserRole");

        builder
            .HasKey(r => r.Id)
            .HasName("PK_IdentityRole_Id");

        builder
            .HasIndex(r => r.NormalizedName, "IX_IdentityRole_NormalizedName")
            .IsUnique();

        builder
            .Property(r => r.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder
            .Property(r => r.Name)
            .HasMaxLength(255);

        builder
            .Property(r => r.NormalizedName)
            .HasMaxLength(255);

    }
}