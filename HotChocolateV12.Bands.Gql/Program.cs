using HotChocolateV12.Musicians.Gql;

using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRepositories()
    .Configure<Config>(builder.Configuration.GetSection(nameof(Config)))
    ;

var config = builder.Services.BuildServiceProvider()
    .GetService<IOptions<Config>>();

builder.Services
    .AddGraphQLDomainService(config!.Value);

var app = builder.Build();

app.MapGraphQL();

app.Run();
