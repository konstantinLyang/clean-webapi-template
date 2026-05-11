using CleanWebApiTemplate.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanWebApiTemplate.Infrastructure.DataAccess.EntityConfiguration;

internal sealed class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasQueryFilter(x => x.IsDeleted != true);
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("bigint")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(x => x.PasswordHash)
            .HasColumnName("password_hash")
            .HasColumnType("varchar(512)")
            .IsRequired();
        
        builder.Property(x => x.FirstName)
            .HasColumnName("first_name")
            .HasColumnType("varchar(100)");

        builder.Property(x => x.LastName)
            .HasColumnName("last_name")
            .HasColumnType("varchar(100)");

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

        builder.HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<string, object>>(
                "user_roles",
                right => right
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("role_id")
                    .OnDelete(DeleteBehavior.Cascade),
                left => left
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("user_id")
                    .OnDelete(DeleteBehavior.Cascade),
                join =>
                {
                    join.ToTable("user_roles");
                    join.HasKey("user_id", "role_id");

                    join.Property<long>("user_id")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    join.Property<long>("role_id")
                        .HasColumnName("role_id")
                        .HasColumnType("bigint");
                });
    }
}
