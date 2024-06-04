namespace Domain.Entities;

public class UserEntity
    : BaseEntity<Guid>
{
    public int RoleId { get; set; }
    
    public string PicturePath { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public RoleEntity Role { get; set; } = default!;
    public List<SessionEntity> Sessions { get; set; } = [];
    public List<OrderEntity> Orders { get; set; } = [];
    public List<ReviewEntity> Reviews { get; set; } = [];
}