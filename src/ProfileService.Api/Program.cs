using ProfileService.Api.OpenApi;
using ProfileService.Api.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApiConfiguration();
builder.Services.AddCorsConfiguration();


//builder.Services.AddInfrastructure(builder.Configuration);
//builder.Services.AddApplication();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApiEndpoints();
}

app.UseCors("Frontend");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
