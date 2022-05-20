using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .Configure<Config>(builder.Configuration.GetSection(nameof(Config)))
    ;

var config = builder.Services.BuildServiceProvider()
    .GetService<IOptions<Config>>();

builder.Services.AddHttpClient(WellKnownSchemaNames.Musicians,
    c => c.BaseAddress = new Uri("http://localhost:5101/graphql"));
builder.Services.AddHttpClient(WellKnownSchemaNames.Bands,
    c => c.BaseAddress = new Uri("http://localhost:5102/graphql"));

builder.Services
    .AddGraphQLGatewayService(config!.Value);

var app = builder.Build();

app.MapGraphQL();

app.Run();
