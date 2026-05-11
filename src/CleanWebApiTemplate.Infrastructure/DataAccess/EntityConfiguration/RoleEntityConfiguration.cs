using CleanWebApiTemplate.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanWebApiTemplate.Infrastructure.DataAccess.EntityConfiguration;

internal sealed class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Name)
            .IsUnique()
            .HasFilter("is_deleted = false");

        builder.HasQueryFilter(x => x.IsDeleted != true);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("bigint")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(x => x.IsDeleted)
            .HasColumnName("is_deleted")
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.HasMany(x => x.Permissions)
            .WithMany(x => x.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "role_permissions",
                right => right
                    .HasOne<Permission>()
                    .WithMany()
                    .HasForeignKey("permission_id")
                    .OnDelete(DeleteBehavior.Cascade),
                left => left
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("role_id")
                    .OnDelete(DeleteBehavior.Cascade),
                join =>
                {
                    join.ToTable("role_permissions");
                    join.HasKey("role_id", "permission_id");

                    join.Property<long>("role_id")
                        .HasColumnName("role_id")
                        .HasColumnType("bigint");

                    join.Property<long>("permission_id")
                        .HasColumnName("permission_id")
                        .HasColumnType("bigint");
                });
    }
}
