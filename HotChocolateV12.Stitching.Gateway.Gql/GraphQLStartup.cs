namespace HotChocolateV12.Stitching.Gateway.Gql;

public static class GraphQLStartup
{
    public static IServiceCollection AddGraphQLGatewayService(
        this IServiceCollection services,
        Config config)
    {
        switch (config.GRAPHQL_SUPERGRAPH_MODE)
        {
            case Config.GraphQLSupergraphMode.HC_V12_SCHEMA_STITCHING:
                services
                    .AddGraphQLServer()
                    // .AddQueryType<Query>();
                    .AddRemoteSchema(WellKnownSchemaNames.Musicians)
                    .AddRemoteSchema(WellKnownSchemaNames.Bands)
                    // .AddQueryFieldToMutationPayloads()
                    // .AddGlobalObjectIdentification()
                    .AddTypeExtensionsFromFile("./Stitching.graphql")
                    ;
                break;
            case Config.GraphQLSupergraphMode.HC_V12_FEDERATION_VIA_POLLING:
                throw new NotImplementedException();
            case Config.GraphQLSupergraphMode.HC_V12_FEDERATION_VIA_REDIS:
                throw new NotImplementedException();
        }

        return services;
    }
}
