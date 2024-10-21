using SamanStore.Web;
using SamanStore.Infrastructure;
using SamanStore.Infrastructure.Persistance;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SamanStore.Infrastructure.Persistance.SeedData;


var builder = WebApplication.CreateBuilder(args);

//Configuration
builder.Services.AddInfrastructureService(builder.Configuration);
builder.AddWebConfigureServise();

var app = builder.Build();
await app.AddWebAppService().ConfigureAwait(false);

