using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings.Identity;

/// <summary>
/// IdentityUserLogin é usado para fazer logins usando
/// plataformas externas como Google, Facebook, Microsoft e etc
/// </summary>

public class IdentityUserLoginMapping 
    : IEntityTypeConfiguration<IdentityUserLogin<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<long>> builder)
    {
        builder.ToTable("IdentityUserLogin");

        builder
            .HasKey(l => new { l.LoginProvider, l.ProviderKey })
            .HasName("PK_IdentityUserLogin_LoginProvider_ProviderKey");

        builder
            .Property(l => l.LoginProvider)
            .HasMaxLength(128);

        builder
            .Property(l => l.ProviderKey)
            .HasMaxLength(128);

        builder
            .Property(u => u.ProviderDisplayName)
            .HasMaxLength(255);
    }
}