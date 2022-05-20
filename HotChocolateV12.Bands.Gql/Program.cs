using HotChocolateV12.Musicians.Gql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    // .AddGlobalObjectIdentification()
    ;

var app = builder.Build();

app.MapGraphQL();

app.Run();
