namespace Infrastructure.Repositories;

public class BookRepository(
    ApplicationDbContext dbContext)
    : IBookRepository
{
    public async Task<PaginatedData<BookEntity>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        var getListQuery = dbContext.Books
            .OrderByDescending(x => x.Created)
            .AsNoTracking();
        var countQuery = dbContext.Books
            .AsNoTracking();
        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            getListQuery = getListQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Description.ToLower().Contains(searchTerms) ||
                u.Author.LastName.ToLower().Contains(searchTerms) ||
                u.Author.FirstName.ToLower().Contains(searchTerms) ||
                u.Author.MiddleName.ToLower().Contains(searchTerms));
            
            countQuery = countQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Description.ToLower().Contains(searchTerms) ||
                u.Author.LastName.ToLower().Contains(searchTerms) ||
                u.Author.FirstName.ToLower().Contains(searchTerms) ||
                u.Author.MiddleName.ToLower().Contains(searchTerms));
        }
        
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.Author)
            .Include(x => x.Genre)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<BookEntity>(
            List: list, TotalCount: totalCount);
    }
}