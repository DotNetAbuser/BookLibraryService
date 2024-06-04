namespace Domain.Configurations;

public class BookConfiguration
    : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Title)
            .IsUnique();

        builder
            .HasOne(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.AuthorId);
        builder
            .HasOne(x => x.Genre)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.GenreId);
        builder
            .HasMany(x => x.Orders)
            .WithOne(x => x.Book);

        builder.HasData(new List<BookEntity>
        {
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 2,
                GenreId = 1,
                PicturePath = "Files//Images//BookPictures//1.jpg",
                Title = "Баш и Люси",
                Description = "Баш и Люси описание",
                Year = 1990,
                Quantity = 3,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 2,
                GenreId = 1,
                PicturePath = "Files//Images//BookPictures//2.jpg",
                Title = "Будь здорова пчелка",
                Description = "Будь здорова пчелка описание",
                Year = 1995,
                Quantity = 2,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 4,
                GenreId = 6,
                PicturePath = "Files//Images//BookPictures//3.jpg",
                Title = "Скучные девчонки",
                Description = "Скучные девчонки описание",
                Year = 2001,
                Quantity = 10,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 5,
                GenreId = 7,
                PicturePath = "Files//Images//BookPictures//4.jpg",
                Title = "Умные земли",
                Description = "умные земли описание",
                Year = 2005,
                Quantity = 12,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 6,
                GenreId = 8,
                PicturePath = "Files//Images//BookPictures//5.jpg",
                Title = "Темная сторона интернета",
                Description = "Темная сторона интернета описание",
                Year = 2012,
                Quantity = 10,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 1,
                GenreId = 8,
                PicturePath = "Files//Images//BookPictures//6.jpg",
                Title = "Экономика агропромышленности",
                Description = "Экономика агропромышленности описание",
                Year = 2000,
                Quantity = 1,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 6,
                GenreId = 6,
                PicturePath = "Files//Images//BookPictures//7.jpg",
                Title = "Свободное падение",
                Description = "Свободное падение описание",
                Year = 2009,
                Quantity = 6,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 1,
                GenreId = 8,
                PicturePath = "Files//Images//BookPictures//8.jpg",
                Title = "Современная архитектура зданий",
                Description = "Современная архитектура зданий описание",
                Year = 2018,
                Quantity = 4,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 7,
                GenreId = 9,
                PicturePath = "Files//Images//BookPictures//9.jpg",
                Title = "Святой дух",
                Description = "Святой дух описание",
                Year = 2001,
                Quantity = 0,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 2,
                GenreId = 10,
                PicturePath = "Files//Images//BookPictures//10.jpg",
                Title = "Апокалипсис Ллойда",
                Description = "Апокалипсис Ллойда описание",
                Year = 2019,
                Quantity = 1,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 1,
                GenreId = 6,
                PicturePath = "Files//Images//BookPictures//11.jpg",
                Title = "Ночная тень",
                Description = "Ночная тень описание",
                Year = 2010,
                Quantity = 9,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 6,
                GenreId = 8,
                PicturePath = "Files//Images//BookPictures//12.jpg",
                Title = "Радикальное садоводство",
                Description = "Радикальное садоводство описание",
                Year = 2010,
                Quantity = 1,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 2,
                GenreId = 9,
                PicturePath = "Files//Images//BookPictures//13.jpg",
                Title = "Красная королева",
                Description = "Красная королева описание",
                Year = 2017,
                Quantity = 10,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 7,
                GenreId = 2,
                PicturePath = "Files//Images//BookPictures//14.jpg",
                Title = "Разбитый",
                Description = "Разбитый описание",
                Year = 2011,
                Quantity = 3,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 2,
                GenreId = 3,
                PicturePath = "Files//Images//BookPictures//15.jpg",
                Title = "Девушки чернил и звёзд",
                Description = "",
                Year = 2013,
                Quantity = 8,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 7,
                GenreId = 1,
                PicturePath = "Files//Images//BookPictures//16.jpg",
                Title = "Счастливый лимон",
                Description = "Счастливый лимон описание",
                Year = 2000,
                Quantity = 12,
            },
            new()
            {
                Id = Guid.NewGuid(),
                AuthorId = 4,
                GenreId = 8,
                PicturePath = "Files//Images//BookPictures//17.jpg",
                Title = "Мир абстрактных цветов",
                Description = "Мир абстрактных цветов!",
                Year = 2020,
                Quantity = 0,
            },
       
        });
    }
}