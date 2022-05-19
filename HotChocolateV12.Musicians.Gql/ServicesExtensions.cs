using HotChocolateV12.Musicians.Gql.Repositories;

namespace HotChocolateV12.Musicians.Gql;

public static class ServicesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddScoped<IMusicianRepository, MusicianRepository>();
}