var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    // .AddGlobalObjectIdentification()
    ;

var app = builder.Build();

app.MapGraphQL();

app.Run();
