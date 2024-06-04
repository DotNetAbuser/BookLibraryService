namespace Shared.Contracts;

public record BookResponse(
    Guid Id,
    string PicturePath,
    string AuthorLastName,
    string AuthorFirstName,
    string AuthorMiddleName,
    string Genre,
    string Title,
    string Description,
    int Year,
    int Count);