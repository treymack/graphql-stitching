using HotChocolateV12.Bands.Gql.Repositories;

namespace HotChocolateV12.Musicians.Gql;

public static class ServicesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddScoped<IBandsRepository, BandsRepository>();
}