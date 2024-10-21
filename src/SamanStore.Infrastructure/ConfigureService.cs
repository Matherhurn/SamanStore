using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SamanStore.Infrastructure.Persistance;
using System.Runtime.CompilerServices;

namespace SamanStore.Infrastructure;

public static class ConfigureService
{
	#region Method
	public static IServiceCollection AddInfrastructureService(this IServiceCollection services,IConfiguration configuration)
	{

       services.AddDbContext<SamanStoreDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
	}
	#endregion
}
