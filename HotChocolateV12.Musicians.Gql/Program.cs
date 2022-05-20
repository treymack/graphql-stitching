using System.Text.Json;

using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRepositories()
    .Configure<Config>(builder.Configuration.GetSection(nameof(Config)))
    ;

var config = builder.Services.BuildServiceProvider()
    .GetService<IOptions<Config>>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    // .AddGlobalObjectIdentification()
    ;

var app = builder.Build();

app.MapGraphQL();

app.Run();
