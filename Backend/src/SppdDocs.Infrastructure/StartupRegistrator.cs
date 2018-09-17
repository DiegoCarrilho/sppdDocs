using System;
using Microsoft.Extensions.DependencyInjection;
using SppdDocs.Core;
using SppdDocs.Core.Interfaces;
using SppdDocs.Core.Services;
using SppdDocs.Infrastructure.Services;

namespace SppdDocs.Infrastructure
{
	public class StartupRegistrator : IStartupRegistrator
	{
		public void RegisterService(IServiceCollection services)
		{
			services.AddScoped<IBasketService, BasketService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddTransient<IEmailSender, EmailSender>();
		}

		public void ConfigureService(IServiceProvider serviceProvider)
		{
		}
	}
}