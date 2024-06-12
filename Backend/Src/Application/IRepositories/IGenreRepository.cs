namespace Application.IRepositories;

public interface IGenreRepository
{
    Task<IEnumerable<GenreEntity>> GetAllAsync();
}