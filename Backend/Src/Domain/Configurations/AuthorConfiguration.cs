namespace Domain.Configurations;

public class AuthorConfiguration
    : IEntityTypeConfiguration<AuthorEntity>
{
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .HasMany(x => x.Books)
            .WithOne(x => x.Author);

        builder.HasData(new List<AuthorEntity>
        {
            new()
            {
                Id = 1,
                LastName = "Шпак",
                FirstName = "Александр",
                MiddleName = string.Empty,
                PicturePath = "Files//Images//AuthorPictures//1.jpg",
            },
            new()
            {
                Id = 2,
                LastName = "Сижулина",
                FirstName = "Оксана",
                MiddleName = string.Empty,
                PicturePath = "Files//Images//AuthorPictures//2.jpg",
            },
            new()
            {
                Id = 3,
                LastName = "Кировский",
                FirstName = "Петр",
                MiddleName = string.Empty,
                PicturePath = "Files//Images//AuthorPictures//3.jpg",
            },
            new()
            {
                Id = 4,
                LastName = "Каитская",
                FirstName = "Адель",
                MiddleName = string.Empty,
                PicturePath = "Files//Images//AuthorPictures//4.jpg",
            },
            new()
            {
                Id = 5,
                LastName = "Кармов",
                FirstName = "Михаил",
                MiddleName = string.Empty,
                PicturePath = "Files//Images//AuthorPictures//5.jpg",
            },
            new()
            {
                Id = 6,
                LastName = "Сергеева",
                FirstName = "Виолета",
                MiddleName = string.Empty,
                PicturePath = "Files//Images//AuthorPictures//6.jpg",
            },
            new()
            {
                Id = 7,
                LastName = "Тураев",
                FirstName = "Азиз",
                MiddleName = "Автор",
                PicturePath = "Files//Images//AuthorPictures//7.jpg"
            }
        });
    }
}