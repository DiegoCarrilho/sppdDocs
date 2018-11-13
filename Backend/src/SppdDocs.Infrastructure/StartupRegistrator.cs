using System;

using Microsoft.Extensions.DependencyInjection;

using SppdDocs.Core;
using SppdDocs.Core.Config;
using SppdDocs.Core.Services;
using SppdDocs.Infrastructure.Config;
using SppdDocs.Infrastructure.Services;

namespace SppdDocs.Infrastructure
{
    public class StartupRegistrator : IStartupRegistrator
    {
        public int Priority => int.MaxValue;

        public void RegisterService(IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddSingleton(typeof(IConfigProvider<>), typeof(ConfigProvider<>));
        }

        public void ConfigureService(IServiceProvider serviceProvider)
        {
        }
    }
}