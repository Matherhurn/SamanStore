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
builder.AddWebServiceCollection();
builder.Services.AddInfrastructureService(builder.Configuration);

var app = builder.Build();


var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var context = app.Services.GetRequiredService<SamanStoreDbContext>();

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
