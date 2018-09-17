using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SppdDocs.Core;
using SppdDocs.Core.Utils.Extensions;
using SppdDocs.Core.Utils.Helpers;

namespace SppdDocs.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			LoadApplicationAssemblies();

			RegisterServiceRegistries(services);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();

			ConfigureServices(app.ApplicationServices);
		}

		/// <summary>
		///     Calls <see cref="IStartupRegistrator.RegisterService" /> on all non-abstract implementations of
		///     <see cref="IStartupRegistrator" />
		/// </summary>
		/// <param name="services">The service collection to register the services on.</param>
		private static void RegisterServiceRegistries(IServiceCollection services)
		{
			var serviceRegistries = GetRegistries<IStartupRegistrator>();
			foreach (var serviceRegistry in serviceRegistries)
			{
				serviceRegistry.RegisterService(services);
			}
		}

		private static void ConfigureServices(IServiceProvider appApplicationServices)
		{
			var dependencyRegistries = GetRegistries<IStartupRegistrator>();
			foreach (var dependencyRegistry in dependencyRegistries)
			{
				dependencyRegistry.ConfigureService(appApplicationServices);
			}
		}

		/// <summary>
		///     Loads the application assemblies (Sppd*.dll) found in the base directory.
		/// </summary>
		private static void LoadApplicationAssemblies()
		{
			var directoryCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory, $"{Constants.Application.SHORT_NAME}*.dll");
			var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).ToList();
			foreach (var assemblyFilePath in directoryCatalog.LoadedFiles)
			{
				var cleanAssemblyFilePath = FileHelper.GetCleanFilePath(assemblyFilePath);
				var isAssemblyRegistered = loadedAssemblies.Any(a => string.Equals(a.GetFilePath(), cleanAssemblyFilePath, StringComparison.InvariantCultureIgnoreCase));
				if (!isAssemblyRegistered)
				{
					// Load the application assembly if it hasn't already been loaded
					Assembly.Load(assemblyFilePath);
				}
			}
		}

		/// <summary>
		///     Gets all the registries registries of type <c>TRegistry</c>.
		/// </summary>
		/// <typeparam name="TRegistry">The type of registry</typeparam>
		/// <returns>A list of instances for all found implementations of type <c>TRegistry</c></returns>
		private static IEnumerable<TRegistry> GetRegistries<TRegistry>()
		{
			var serviceRegistryType = typeof(TRegistry);
			var serviceRegistryImplementationTypes = AppDomain.CurrentDomain.GetAssemblies()
			                                                  .SelectMany(s => s.GetTypes())
			                                                  .Where(p => p.IsClass && !p.IsAbstract && serviceRegistryType.IsAssignableFrom(p));

			foreach (var serviceRegistryImplementationType in serviceRegistryImplementationTypes)
			{
				yield return (TRegistry) Activator.CreateInstance(serviceRegistryImplementationType);
			}
		}
	}
}