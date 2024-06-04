namespace Shared.Enums;

public enum UploadType : byte
{
    [Description(@"Images\ProfilePictures")]
    ProfilePicture = 1,
    
    [Description(@"Images\AuthorPictures")]
    AuthorPicture = 2,
    
    [Description(@"Images\BookPictures")]
    BookPicture = 3,
}