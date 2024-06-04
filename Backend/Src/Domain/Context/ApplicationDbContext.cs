namespace Domain.Context;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<SessionEntity> Sessions { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    public DbSet<ReviewEntity> Reviews { get; set; }

    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books { get; set; }

    public DbSet<OrderStatusEntity> OrderStatuses { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new SessionConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.ApplyConfiguration(new ReviewConfiguration());

        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());

        modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}