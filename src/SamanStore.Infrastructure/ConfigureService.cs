using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace SamanStore.Infrastructure;

public static class ConfigureService
{
	#region Method
	public static IServiceCollection AddInfrastructureService(this IServiceCollection services,IConfiguration configuration)
	{
		return services;
	}
	#endregion
}
