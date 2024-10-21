using SamanStore.Web;
using SamanStore.Infrastructure;
using SamanStore.Infrastructure.Persistance;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SamanStore.Infrastructure.Persistance.SeedData;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuration
builder.Services.AddInfrastructureService(builder.Configuration);
builder.AddWebServiceCollection();

var app = builder.Build();
//get service 
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var loggerFactory = services.GetRequiredService<ILoggerFactory>();
var context = services.GetRequiredService<SamanStoreDbContext>();

//auto migration
try
{
    await context.Database.MigrateAsync();
    await GenerateSeedData.SeedDataAsync(context, loggerFactory);
}
catch (Exception e)
{
    var loggger = loggerFactory.CreateLogger<Program>();
    loggger.LogError(e,"Erro for Migration");

}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
