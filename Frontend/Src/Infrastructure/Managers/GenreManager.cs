namespace Infrastructure.Managers;

public interface IGenreManager
{
    Task<IResult<IEnumerable<GenreResponse>>> GetAllAsync();

}

public class GenreManager(
    IHttpClientFactory factory)
    : IGenreManager
{
    public async Task<IResult<IEnumerable<GenreResponse>>> GetAllAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(GenreRoutes.GetAll);
        return await response.ToResultAsync<IEnumerable<GenreResponse>>();
    }
}