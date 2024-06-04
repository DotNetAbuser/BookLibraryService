namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddManagers(this IServiceCollection services) =>
        services
            .AddTransient<ITokenManager, TokenManager>();

    public static void AddServices(this IServiceCollection services) =>
        services
            .AddTransient<IAuthorManager, AuthorManager>()
            .AddTransient<IBookManager, BookManager>()
            .AddTransient<IGenreManager, GenreManager>()
            .AddTransient<IOrderManager, OrderManager>()
            .AddTransient<IOrderStatusManager, OrderStatusManager>()
            .AddTransient<IReviewManager, ReviewManager>()
            .AddTransient<ITokenService, TokenService>()
            .AddTransient<IUserManager, UserManager>();

    public static void AddAndConfigureHttpClientFactory(this IServiceCollection services) =>
        services
            .AddTransient<AuthorizationHeaderHandler>()
            .AddHttpClient(ApplicationConstants.BaseClientName)
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(ApplicationConstants.BackendAddress))
            .AddHttpMessageHandler<AuthorizationHeaderHandler>();
}