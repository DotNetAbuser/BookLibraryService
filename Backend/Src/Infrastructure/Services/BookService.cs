namespace Infrastructure.Services;

public class BookService(
    IBookRepository bookRepository,
    IUploadFileHelper uploadFileHelper)
    : IBookService
{
    public async Task<Result<int>> GetCountAsync()
    {
        var booksCount = await bookRepository.GetCountAsync();
        return Result<int>.Success(booksCount, "Кол-во книг успешно получено.");
    }

    public async Task<Result<PaginatedData<BookResponse>>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        var (booksEntities, totalCount) = await bookRepository.GetPaginatedBooksAsync(
            pageNumber, pageSize, searchTerms);
        var booksResponse = booksEntities.Select(bookEntity =>
            new BookResponse(
                Id: bookEntity.Id,
                PicturePath: bookEntity.PicturePath,
                AuthorId: bookEntity.AuthorId,
                GenreId: bookEntity.GenreId,
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

    public async Task<Result<BookResponse>> GetByIdAsync(Guid id)
    {
        var bookEntity = await bookRepository.GetByIdWithIncludesAsync(id);
        if (bookEntity == null)
            return Result<BookResponse>.Fail("Книга с данным идентификатором не существует!");

        var bookResponse = new BookResponse(
            Id: bookEntity.Id,
            PicturePath: bookEntity.PicturePath,
            AuthorId: bookEntity.AuthorId,
            GenreId: bookEntity.GenreId,
            AuthorLastName: bookEntity.Author.LastName,
            AuthorFirstName: bookEntity.Author.FirstName,
            AuthorMiddleName: bookEntity.Author.MiddleName,
            Genre: bookEntity.Genre.Name,
            Title: bookEntity.Title,
            Description: bookEntity.Description,
            Year: bookEntity.Year,
            Quantity: bookEntity.Quantity);
        return Result<BookResponse>.Success(bookResponse,"Книга успешно получена.");
    }

    public async Task<Result> CreateAsync(CreateBookRequest request)
    {
        var isExistByTitle = await bookRepository.IsExistByTitleAsync(request.Title);
        if (isExistByTitle)
            return Result<string>.Fail("Книга с данным названием уже существует!");

        var picturePath = uploadFileHelper.UploadFile(request.BookPictureRequest);
        
        var bookEntity = new BookEntity {
            AuthorId = request.AuthorId,
            GenreId = request.GenreId,
            PicturePath = picturePath,
            Title = request.Title,
            Description = request.Description,
            Year = request.Year,
            Quantity = request.Quantity
        };

        await bookRepository.CreateAsync(bookEntity);
        return Result<string>.Success("Книга успешно добавлена в систему.");
    }

    public async Task<Result> UpdateAsync(Guid id, UpdateBookRequest request)
    {
        var isExistForUpdateByTitle = await bookRepository.IsExistForUpdateByTitleAsync(id,request.Title);
        if (isExistForUpdateByTitle)
            return Result<string>.Fail("Книга с таким же названием уже существует!");

        var bookEntity = await bookRepository.GetByIdAsync(id);
        if (bookEntity == null)
            return Result<string>.Fail("Книга с данным идентификатором не найдена!");

        if (request.BookPictureRequest != null)
            bookEntity.PicturePath = uploadFileHelper.UploadFile(request.BookPictureRequest);
        
        bookEntity.AuthorId = request.AuthorId;
        bookEntity.GenreId = request.GenreId;
        bookEntity.Title = request.Title;
        bookEntity.Description = request.Description;
        bookEntity.Year = request.Year;
        bookEntity.Quantity = request.Quantity;
        bookEntity.Updated = DateTime.UtcNow;

        await bookRepository.UpdateAsync(bookEntity);
        return Result<string>.Success("Книга успешно обновлена.");
    }

    public async Task<Result> DeleteAsync(Guid id)
    { 
        var bookEntity = await bookRepository.GetByIdAsync(id);
        if (bookEntity == null)
            return Result<string>.Fail("Книга с данным идентификатором не найдена!");

        await bookRepository.DeleteAsync(bookEntity);
        return Result<string>.Success("Книга успешно удалена!");
    }
}