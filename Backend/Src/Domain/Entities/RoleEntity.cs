namespace Domain.Entities;

public class RoleEntity
    : BaseEntity<int>
{
    public string Name { get; set; }

    public List<UserEntity> Users { get; set; } = [];
}