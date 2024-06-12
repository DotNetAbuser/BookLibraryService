namespace Infrastructure.Services;

public class GenreService(
    IGenreRepository genreRepository)
    : IGenreService
{
    public async Task<Result<IEnumerable<GenreResponse>>> GetAllAsync()
    {
        var genresEntities = await genreRepository.GetAllAsync();
        var genresResponse = genresEntities
            .Select(genreEntity =>
                new GenreResponse(
                    Id: genreEntity.Id,
                    Name: genreEntity.Name)).ToList();
        return Result<IEnumerable<GenreResponse>>.Success(genresResponse, "Жанры успешно получены.");
    }
}