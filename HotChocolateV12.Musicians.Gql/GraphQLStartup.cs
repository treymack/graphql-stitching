using static HotChocolateV12.Musicians.Gql.Config;

namespace HotChocolateV12.Musicians.Gql;

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
            .InitializeOnStartup()
            .PublishSchemaDefinition(c =>
            {
                c.SetName("musicians");
                c.AddTypeExtensionsFromFile("./Stitching.graphql");
            })
            ;

        return services;
    }

    private static IServiceCollection AddHCV12RedisFederationDomainService(IServiceCollection services)
    {
        throw new NotImplementedException();
    }
}
