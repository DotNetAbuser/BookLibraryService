namespace Shared.Contracts;

public record AuthorResponse(
    int Id,
    string PicturePath,
    string LastName,
    string FirstName,
    string MiddleName);