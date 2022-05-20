var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(WellKnownSchemaNames.Musicians,
    c => c.BaseAddress = new Uri("http://localhost:5101/graphql"));
builder.Services.AddHttpClient(WellKnownSchemaNames.Bands,
    c => c.BaseAddress = new Uri("http://localhost:5102/graphql"));

builder.Services
    .AddGraphQLServer()
    // .AddQueryType<Query>();
    .AddRemoteSchema(WellKnownSchemaNames.Musicians)
    .AddRemoteSchema(WellKnownSchemaNames.Bands)
    // .AddQueryFieldToMutationPayloads()
    // .AddGlobalObjectIdentification()
    ;

var app = builder.Build();

app.MapGraphQL();

app.Run();
