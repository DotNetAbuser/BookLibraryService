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

        /*builder.HasData(new List<BookEntity>
        {

        });*/
    }
}