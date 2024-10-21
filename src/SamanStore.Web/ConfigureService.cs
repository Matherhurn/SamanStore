using Microsoft.EntityFrameworkCore;
using SamanStore.Infrastructure.Persistance;
using SamanStore.Infrastructure.Persistance.SeedData;

namespace SamanStore.Web
{
    public static class ConfigureService
    {
        #region Methoths

        #region AddWebServiceCollection
        public static IServiceCollection AddWebConfigureServise(this WebApplicationBuilder builder)
        {
            #region Swagger
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            return builder.Services;
        }
        #endregion

        #region AddWebAppService       
        public static async Task<IApplicationBuilder> AddWebAppService(this WebApplication app)
        {
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
                loggger.LogError(e, "Erro for Migration");

            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();

            return app;
        }
        #endregion

        #endregion
    }
}
