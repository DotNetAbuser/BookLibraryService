namespace Domain.Configurations;

public class RoleConfiguration
    : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .HasMany(x => x.Users)
            .WithOne(x => x.Role);
    }
}