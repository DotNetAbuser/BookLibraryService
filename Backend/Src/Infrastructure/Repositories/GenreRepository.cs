namespace Infrastructure.Repositories;

public class GenreRepository(
    ApplicationDbContext dbContext)
    : IGenreRepository
{
    public async Task<IEnumerable<GenreEntity>> GetAllAsync()
    {
        return await dbContext.Genres
            .AsNoTracking()
            .ToListAsync();
    }
}