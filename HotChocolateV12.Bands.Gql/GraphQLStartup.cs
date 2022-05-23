using StackExchange.Redis;

using static HotChocolateV12.Bands.Gql.Config;

namespace HotChocolateV12.Bands.Gql;

public static class GraphQLStartup
{
    public static IServiceCollection AddGraphQLDomainService(
        this IServiceCollection services, Config config) =>
        config.GRAPHQL_SUPERGRAPH_MODE switch
        {
            GraphQLSupergraphMode.HC_V12_SCHEMA_STITCHING =>
                AddHCV12SchemaStitchingDomainService(services),
            GraphQLSupergraphMode.HC_V12_FEDERATION_VIA_PULL =>
                AddHCV12PullFederationDomainService(services),
            GraphQLSupergraphMode.HC_V12_FEDERATION_VIA_REDIS =>
                AddHCV12RedisFederationDomainService(services),
            _ => throw new NotImplementedException(),
        };

    private static IServiceCollection AddHCV12SchemaStitchingDomainService(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            // .AddGlobalObjectIdentification()
            ;

        return services;
    }

    private static IServiceCollection AddHCV12PullFederationDomainService(IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .PublishSchemaDefinition(c =>
            {
                c.SetName("bands");
                c.AddTypeExtensionsFromFile("./Stitching.graphql");
            })
            ;

        return services;
    }

    private static IServiceCollection AddHCV12RedisFederationDomainService(IServiceCollection services)
    {
        services
            .AddSingleton(ConnectionMultiplexer.Connect("localhost"))
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .InitializeOnStartup()
            .PublishSchemaDefinition(c =>
            {
                c.SetName("bands");
                c.AddTypeExtensionsFromFile("./Stitching.graphql");
                c.PublishToRedis("SupergraphDemo", sp => sp.GetRequiredService<ConnectionMultiplexer>());
            })
            ;

        return services;
    }
}
