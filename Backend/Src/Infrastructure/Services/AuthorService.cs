namespace Infrastructure.Services;

public class AuthorService(
    IAuthorRepository authorRepository)
    : IAuthorService
{
    public async Task<Result<PaginatedData<AuthorResponse>>> GetPaginatedAuthorsAsync(
        int pageNumber, int pageSize)
    {
        var (authorEntities, totalCount) = await authorRepository.GetPaginatedAuthorsAsync(
            pageNumber, pageSize);
        var authorsResponse = authorEntities.Select(authorEntity => 
            new AuthorResponse(
                Id: authorEntity.Id,
                PicturePath: authorEntity.PicturePath,
                LastName: authorEntity.LastName,
                FirstName: authorEntity.FirstName,
                MiddleName: authorEntity.MiddleName)).ToList();
        return Result<PaginatedData<AuthorResponse>>
            .Success(new PaginatedData<AuthorResponse>(
                List: authorsResponse, TotalCount: totalCount), "Список авторов успешно получен.");
    }

    public async Task<Result<IEnumerable<AuthorResponse>>> GetAllAsync()
    {
        var authorsEntities = await authorRepository.GetAllAsync();
        var authorsResponse = authorsEntities
            .Select(authorEntity => 
                new AuthorResponse(
                    Id: authorEntity.Id,
                    PicturePath: authorEntity.PicturePath,
                    LastName: authorEntity.LastName,
                    FirstName: authorEntity.FirstName,
                    MiddleName: authorEntity.MiddleName)).ToList();
        return Result<IEnumerable<AuthorResponse>>.Success(authorsResponse, "Список всех авторов успешно получен.");
    }
}