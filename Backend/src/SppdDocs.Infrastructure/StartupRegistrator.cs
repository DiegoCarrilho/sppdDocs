using System;
using Microsoft.Extensions.DependencyInjection;
using SppdDocs.Core;
using SppdDocs.Core.Services;
using SppdDocs.Infrastructure.Services;

namespace SppdDocs.Infrastructure
{
	public class StartupRegistrator : IStartupRegistrator
	{
		public void RegisterService(IServiceCollection services)
		{
			services.AddScoped<ICardService, CardService>();
		}

		public void ConfigureService(IServiceProvider serviceProvider)
		{
		}
	}
}