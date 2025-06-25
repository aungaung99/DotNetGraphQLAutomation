using DotNetGraphQLAutomation.API.GraphQL.Brands;
using DotNetGraphQLAutomation.API.GraphQL.Colors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DotNetAutomationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddMutationType(d => d.Name("Mutation"))
    .AddType<BrandType>()
    .AddTypeExtension<BrandQuery>()
    .AddTypeExtension<BrandMutation>()
    .AddType<ColorType>()
    .AddTypeExtension<ColorQuery>()
    .AddTypeExtension<ColorMutation>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Map GraphQL endpoint
app.MapGraphQL();

app.Run();
