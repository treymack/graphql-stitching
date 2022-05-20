namespace HotChocolateV12.Bands.Gql;

public class Config
{
    public GraphQLSupergraphMode? GRAPHQL_SUPERGRAPH_MODE { get; set; }

    public enum GraphQLSupergraphMode
    {
        HC_V12_SCHEMA_STITCHING,
        HC_V12_FEDERATION_VIA_PULL,
        HC_V12_FEDERATION_VIA_REDIS,
    }
}
