namespace Domain.Configurations;

public class OrderStatusConfiguration
    : IEntityTypeConfiguration<OrderStatusEntity>
{
    public void Configure(EntityTypeBuilder<OrderStatusEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .HasMany(x => x.Orders)
            .WithOne(x => x.Status);

        builder.HasData(new List<OrderStatusEntity>
        {
            new()
            {
                Id = (int)Status.WaitingTaking,
                Name = "Ожидает получения"
            },
            new()
            {
                Id = (int)Status.InTaken,
                Name = "Взята в пользование"
            },
            new()
            {
              Id  = (int)Status.ExtendWaiting,
              Name = "Ожидается подтверждения продления"
            },
            new()
            {
                Id = (int)Status.WaitingReturning,
                Name = "Ожидает возврата" 
            },
            new()
            {
                Id = (int)Status.Closed,
                Name = "Закрыта" 
            }
        });
    }
}