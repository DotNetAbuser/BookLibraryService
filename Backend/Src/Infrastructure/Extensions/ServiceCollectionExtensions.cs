namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHelpers(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IUploadFileHelper, UploadFileHelper>();
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IAuthorRepository, AuthorRepository>()
            .AddTransient<IBookRepository, BookRepository>()
            .AddTransient<IGenreRepository, GenreRepository>()
            .AddTransient<IOrderRepository, OrderRepository>()
            .AddTransient<IOrderStatusRepository, OrderStatusRepository>()
            .AddTransient<IReviewRepository, ReviewRepository>()
            .AddTransient<IRoleRepository, RoleRepository>()
            .AddTransient<ISessionRepository, SessionRepository>()
            .AddTransient<IUserRepository, UserRepository>();

    }

    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IAuthorService, AuthorService>()
            .AddTransient<IBookService, BookService>()
            .AddTransient<IGenreService, GenreService>()
            .AddTransient<IOrderService, OrderService>()
            .AddTransient<IOrderStatusService, OrderStatusService>()
            .AddTransient<IReviewService, ReviewService>()
            .AddTransient<ITokenService, TokenService>()
            .AddTransient<IUserService, UserService>();
    }
}