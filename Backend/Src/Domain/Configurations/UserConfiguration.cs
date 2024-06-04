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
            .HasIndex(x => x.Username)
            .IsUnique();

        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);
        builder
            .HasMany(x => x.Sessions)
            .WithOne(x => x.User);
        builder
            .HasMany(x => x.Orders)
            .WithOne(x => x.User);
        builder
            .HasMany(x => x.Reviews)
            .WithOne(x => x.User);

        builder.HasData(new List<UserEntity>
        {
            // Default Users
            new() 
            {
               Id = Guid.NewGuid(),
               RoleId = (int)Role.Guest,
               PicturePath = "Files//Images//ProfilePictures//7.jpg",
               Email = "aziz_guest@gmail.com",
               Username = "aziz_guest",
               PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("1234567890")
            },
            new() 
            {
                Id = Guid.NewGuid(),
                RoleId = (int)Role.Admin,
                PicturePath = "Files//Images//ProfilePictures//7.jpg",
                Email = "aziz_admin@gmail.com",
                Username = "aziz_admin",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("1234567890")
            },
            
            // Users Review
            new()
            {
                Id = Guid.Parse("cdc4a3b4-125f-47f6-8a26-99d057c47d5b"),
                RoleId = (int)Role.Guest,
                PicturePath = "Files//Images//ProfilePictures//1.png",
                Email = "amir_guest@gmail.com",
                Username = "amir_hairulin",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("1234567890")
            },
            new()
            {
                Id = Guid.Parse("7e47a9d9-c095-4cfc-bd5d-4d5428b760e5"),
                RoleId = (int)Role.Guest,
                PicturePath = "Files//Images//ProfilePictures//2.png",
                Email = "adel_guest@gmail.com",
                Username = "adel_shpahina",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("1234567890")
            },
            new()
            {
                Id = Guid.Parse("08278464-1115-440e-b6ab-5f70d77db79d"),
                RoleId = (int)Role.Guest,
                PicturePath = "Files//Images//ProfilePictures//3.png",
                Email = "bulat_guest@gmail.com",
                Username = "bulat_zakirov",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("1234567890")
            },
            new()
            {
                Id = Guid.Parse("2f25fde8-c877-407c-adc9-cad036363c53"),
                RoleId = (int)Role.Guest,
                PicturePath = "Files//Images//ProfilePictures//4.png",
                Email = "ilsia_guest@gmail.com",
                Username = "ilsia_iabarova",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("1234567890")
            },
            new()
            {
                Id = Guid.Parse("da9b2344-4237-4868-ad78-5e1e35a467fe"),
                RoleId = (int)Role.Guest,
                PicturePath = "Files//Images//ProfilePictures//5.png",
                Email = "serega_guest@gmail.com",
                Username = "serega_michurin",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("1234567890")
            },
            new()
            {
                Id = Guid.Parse("85e3c09a-fa0c-4499-97c8-64644e588023"),
                RoleId = (int)Role.Guest,
                PicturePath = "Files//Images//ProfilePictures//6.png",
                Email = "maria_guest@gmail.com",
                Username = "maria_utiasova",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("1234567890")
            }
        });
    }
}