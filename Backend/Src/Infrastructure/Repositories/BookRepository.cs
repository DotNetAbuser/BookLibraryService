﻿namespace Infrastructure.Repositories;

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

    public async Task<BookEntity?> GetByIdWithIncludesAsync(Guid id)
    {
        return await dbContext.Books
            .AsNoTracking()
            .Include(x => x.Author)
            .Include(x => x.Genre)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<BookEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Books
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(BookEntity entity)
    {
        await dbContext.Books.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(BookEntity entity)
    {
        dbContext.Books.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(BookEntity entity)
    {
        dbContext.Books.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistByTitleAsync(string title)
    {
        return await dbContext.Books
            .AsNoTracking()
            .AnyAsync(x => x.Title == title);
    }

    public async Task<bool> IsExistForUpdateByTitleAsync(Guid id, string title)
    {
        return await dbContext.Books
            .AsNoTracking()
            .AnyAsync(x => x.Title == title && x.Id != id);
    }

    public async Task<int> GetCountAsync()
    {
        return await dbContext.Books
            .AsNoTracking()
            .CountAsync();
    }
}