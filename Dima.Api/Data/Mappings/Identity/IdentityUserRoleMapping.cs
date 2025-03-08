using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings.Identity;

public class IdentityUserRoleMapping
    : IEntityTypeConfiguration<IdentityUserRole<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<long>> builder)
    {
        builder.ToTable("IdentityUserRole");

        builder
            .HasKey(ur => new { ur.UserId, ur.RoleId })
            .HasName("PK_Identity_UserId_RoleId");
    }
}