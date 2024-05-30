namespace Domain.Configurations;

public class UserConfiguration
    : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Email)
            .IsUnique();
        builder
            .HasIndex(x => x.PhoneNumber)
            .IsUnique();
        builder
            .HasIndex(x => x.Username)
            .IsUnique();

        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);
        builder
            .HasMany(x => x.Sessions)
            .WithOne(x => x.User);
    }
}