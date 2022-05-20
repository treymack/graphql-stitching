using static HotChocolateV12.Stitching.Gateway.Gql.Config;

namespace HotChocolateV12.Stitching.Gateway.Gql;

public static class GraphQLStartup
{
    public static IServiceCollection AddGraphQLGatewayService(
        this IServiceCollection services, Config config) =>
        config.GRAPHQL_SUPERGRAPH_MODE switch
        {
            GraphQLSupergraphMode.HC_V12_SCHEMA_STITCHING =>
                AddHCV12SchemaStitchingGatewayService(services),
            GraphQLSupergraphMode.HC_V12_FEDERATION_VIA_POLLING =>
                AddHCV12PollingFederationGatewayService(services),
            GraphQLSupergraphMode.HC_V12_FEDERATION_VIA_REDIS =>
                AddHCV12RedisFederationGatewayService(services),
            _ => throw new NotImplementedException(),
        };

    private static IServiceCollection AddHCV12SchemaStitchingGatewayService(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            // .AddQueryType<Query>();
            .AddRemoteSchema(WellKnownSchemaNames.Musicians)
            .AddRemoteSchema(WellKnownSchemaNames.Bands)
            // .AddQueryFieldToMutationPayloads()
            // .AddGlobalObjectIdentification()
            .AddTypeExtensionsFromFile("./Stitching.graphql")
            ;

        return services;
    }

    private static IServiceCollection AddHCV12PollingFederationGatewayService(IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddRemoteSchema(WellKnownSchemaNames.Musicians)
            .AddRemoteSchema(WellKnownSchemaNames.Bands)
            ;

        return services;
    }

    private static IServiceCollection AddHCV12RedisFederationGatewayService(IServiceCollection services)
    {
        throw new NotImplementedException();
    }
}
