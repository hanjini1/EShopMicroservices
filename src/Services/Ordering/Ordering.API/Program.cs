var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services
    .AddApplicationService()
    .AddInfrastructureService(builder.Configuration)
    .AddApiServices();
var app = builder.Build();
app.UseApiServices();
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
