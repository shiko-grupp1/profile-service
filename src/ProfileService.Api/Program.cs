using ProfileService.Api.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApiConfiguration();

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
