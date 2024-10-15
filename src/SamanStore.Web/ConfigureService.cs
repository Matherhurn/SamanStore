using Microsoft.EntityFrameworkCore;
using SamanStore.Infrastructure.Persistance;

namespace SamanStore.Web
{
    public static class ConfigureService
    {
        #region Methoths

        #region AddWebServiceCollection
        public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SamanStoreDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            return builder.Services;
        }
        #endregion

        #endregion


    }
}
