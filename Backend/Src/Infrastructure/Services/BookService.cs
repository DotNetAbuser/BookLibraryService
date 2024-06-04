namespace Infrastructure.Services;

public class BookService(
    IBookRepository bookRepository)
    : IBookService
{
    public async Task<Result<PaginatedData<BookResponse>>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        var (booksEntities, totalCount) = await bookRepository.GetPaginatedBooksAsync(
            pageNumber, pageSize, searchTerms);
        var booksResponse = booksEntities.Select(bookEntity =>
            new BookResponse(
                Id: bookEntity.Id,
                PicturePath: bookEntity.PicturePath,
                AuthorLastName: bookEntity.Author.LastName,
                AuthorFirstName: bookEntity.Author.FirstName,
                AuthorMiddleName: bookEntity.Author.MiddleName,
                Genre: bookEntity.Genre.Name,
                Title: bookEntity.Title,
                Description: bookEntity.Description,
                Year: bookEntity.Year,
                Quantity: bookEntity.Quantity)).ToList();
        return Result<PaginatedData<BookResponse>>
            .Success(new PaginatedData<BookResponse>(
                List: booksResponse, TotalCount: totalCount), "Список книг успешно получен.");
    }
}