using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SppdDocs.Core;
using SppdDocs.Core.Domain.Repositories;
using SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders;
using SppdDocs.Infrastructure.DbAccess.Repositories;
using SppdDocs.Infrastructure.DbAccess.Seeder;

namespace SppdDocs.Infrastructure.DbAccess
{
	// ReSharper disable once UnusedMember.Global
	public class StartupRegistrator : IStartupRegistrator
	{
		public void RegisterService(IServiceCollection services)
		{
			// SppdContext
			// TODO: read connection string from config
			var connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=Sppd; Integrated Security=true; MultipleActiveResultSets=True;";
			services.AddDbContext<SppdContext>(options => options.UseSqlServer(connectionString));

			// Repositories
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
			services.AddScoped(typeof(IRepositoryVersioned<>), typeof(RepositoryVersioned<>));

#if DEBUG
			// DB Seeders
			services.AddScoped(typeof(IDbSeeder), typeof(CardDbSeeder));
			//services.AddScoped(typeof(IDbSeeder), typeof(CardAbilityDbSeeder));
#endif

			// Other
			services.AddScoped(typeof(IEntityMetadataProvider), typeof(BaseEntityMetadataProvider));
		}

		public void ConfigureService(IServiceProvider serviceProvider)
		{
			using (var serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<SppdContext>();
#if DEBUG
				context.Database.EnsureDeleted();
				if (context.Database.EnsureCreated())
				{
					foreach (var seeder in serviceScope.ServiceProvider.GetServices<IDbSeeder>().OrderBy(seeder => seeder.Priority))
					{
						seeder.Seed();
					}
				}
#else
				context.Database.Migrate();
#endif
			}
		}
	}
}