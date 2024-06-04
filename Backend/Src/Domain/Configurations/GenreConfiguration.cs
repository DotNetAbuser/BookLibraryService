namespace Domain.Configurations;

public class GenreConfiguration
    : IEntityTypeConfiguration<GenreEntity>
{
    public void Configure(EntityTypeBuilder<GenreEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .HasMany(x => x.Books)
            .WithOne(x => x.Genre);

        builder.HasData(new List<GenreEntity>
        {
            new()
            {
                Id = 1,
                Name = "Сказки"
            },
            new()
            {
                Id = 2,
                Name = "Детектив"
            },
            new()
            {
                Id = 3,
                Name = "Роман"
            },
            new()
            {
                Id = 4,
                Name = "Комедия"
            },
            new()
            {
                Id = 5,
                Name = "Драма"
            },
            new()
            {
                Id = 6,
                Name = "Новелла"
            },
            new()
            {
                Id = 7,
                Name = "Бизнес"
            },
            new()
            {
                Id = 8,
                Name = "Образование"
            },
            new()
            {
                Id = 9,
                Name = "Мистика"
            },
            new()
            {
                Id = 10,
                Name = "Черный юмор"
            }
        });
    }
}