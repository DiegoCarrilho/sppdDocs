using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SppdDocs.Core;
using SppdDocs.Core.Config;
using SppdDocs.Core.Utils.Extensions;
using SppdDocs.Core.Utils.Helpers;
using SppdDocs.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace SppdDocs
{
	public class Startup
	{
		private static readonly ILog s_logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			s_logger.Debug("Start configuring services");

			LoadApplicationAssemblies();

			// Use AutoMapper
			services.AddAutoMapper();

			// Workaround to fix exception 'Cannot choose between multiple constructors with equal length 2 on type
			// 'Microsoft.Extensions.Logging.LoggerFactory' See: https://github.com/aspnet/Logging/issues/691
			services.AddSingleton<ILoggerFactory>(sp => new LoggerFactory(sp.GetServices<ILoggerProvider>()));

			RegisterServiceRegistries(services);

			// The configs are only available after the services have been registered
			var generalConfig = GetGeneralConfig(services.BuildServiceProvider());
			if (generalConfig.EnableSwaggerUI)
			{
				// Make SwaggerUI available
				services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });
			}

			services.AddMvc()
			        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			s_logger.Info("Services have been configured");
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			var generalConfig = GetGeneralConfig(app.ApplicationServices);

			s_logger.Debug("Start configuring application");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			if (generalConfig.EnableSwaggerUI)
			{
				// Enable middleware to serve generated Swagger as a JSON endpoint.
				app.UseSwagger();

				// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
				// specifying the Swagger JSON endpoint.
				var swaggerEndpoint = "/swagger/v1/swagger.json";
				app.UseSwaggerUI(c => { c.SwaggerEndpoint(swaggerEndpoint, "API V1"); });

				s_logger.Info($"SwaggerUI has been enabled on '{swaggerEndpoint}'");
			}

			// Log all uncaught exceptions
			app.UseGlobalExceptionHandler();

			app.UseHttpsRedirection();
			app.UseMvc();

			ConfigureServices(app.ApplicationServices);

			s_logger.Info("Application is ready");
		}

		/// <summary>
		///     Calls <see cref="IStartupRegistrator.RegisterService" /> on all non-abstract implementations of
		///     <see cref="IStartupRegistrator" />
		/// </summary>
		/// <param name="services">The service collection to register the services on.</param>
		private static void RegisterServiceRegistries(IServiceCollection services)
		{
			var serviceRegistries = GetRegistries<IStartupRegistrator>();
			foreach (var serviceRegistry in serviceRegistries.OrderByDescending(s => s.Priority))
			{
				serviceRegistry.RegisterService(services);
			}
		}

		private static void ConfigureServices(IServiceProvider appApplicationServices)
		{
			var dependencyRegistries = GetRegistries<IStartupRegistrator>();
			foreach (var dependencyRegistry in dependencyRegistries.OrderByDescending(s => s.Priority))
			{
				dependencyRegistry.ConfigureService(appApplicationServices);
			}
		}

		/// <summary>
		///     Loads the application assemblies (Sppd*.dll) found in the base directory.
		/// </summary>
		private static void LoadApplicationAssemblies()
		{
			s_logger.Debug("Start dynamic assembly loading");

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
					s_logger.Info($"Dynamically loaded assembly '{assemblyFilePath}'");
				}
			}

			s_logger.Info("Finished dynamically loading assemblies");
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

		private static GeneralConfig GetGeneralConfig(IServiceProvider serviceProvider)
		{
			return serviceProvider.GetService<IConfigProvider<GeneralConfig>>().Config;
		}
	}
}