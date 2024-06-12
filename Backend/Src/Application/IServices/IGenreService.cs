namespace Application.IServices;

public interface IGenreService
{
    Task<Result<IEnumerable<GenreResponse>>> GetAllAsync();
}