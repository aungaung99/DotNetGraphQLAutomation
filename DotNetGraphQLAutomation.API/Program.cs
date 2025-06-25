using DotNetGraphQLAutomation.API.GraphQL.Brands;
using DotNetGraphQLAutomation.API.GraphQL.Colors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DotNetAutomationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS policy to allow Angular app on localhost:4200
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
});

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

// Use CORS policy
app.UseCors("AllowAngularLocalhost");

app.UseAuthorization();

app.MapControllers();

// Map GraphQL endpoint
app.MapGraphQL();

app.Run();
