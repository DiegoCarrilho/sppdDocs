using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SppdDocs.Core;
using SppdDocs.Core.Interfaces;

namespace SppdDocs.Infrastructure.DbAccess
{
	// ReSharper disable once UnusedMember.Global
	public class StartupRegistrator : IStartupRegistrator
	{
		public void RegisterService(IServiceCollection services)
		{
			// TODO: read connection string from config
			var connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=Sppd; Integrated Security=true; MultipleActiveResultSets=True;";
			services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
			services.AddScoped<IOrderRepository, OrderRepository>();
		}

		public void ConfigureService(IServiceProvider serviceProvider)
		{
			using (var serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<Context>();
				//context.Database.Migrate();
				context.Database.EnsureCreated();
			}
		}
	}
}