using System;
using System.Threading;
using Microsoft.Extensions.Configuration;
using SppdDocs.Core.Config;

namespace SppdDocs.Infrastructure.Config
{
    /// <summary>
    ///     Provider that delivers populated <see cref="IConfig" /> objects.
    /// </summary>
    /// <typeparam name="TConfig">Type of the configuration</typeparam>
    /// <seealso cref="SppdDocs.Core.Config.IConfigProvider{T}" />
    public class ConfigProvider<TConfig> : IConfigProvider<TConfig>
        where TConfig : class, IConfig, new()
    {
        private readonly Lazy<TConfig> _config;
        private readonly IConfiguration _configuration;

        public ConfigProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            _config = new Lazy<TConfig>(CreateBoundConfig, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public TConfig Config => _config.Value;

        private TConfig CreateBoundConfig()
        {
            var configValues = new TConfig();

            if (string.IsNullOrWhiteSpace(configValues.SectionKey))
            {
                _configuration.Bind(configValues);
            }
            else
            {
                _configuration.Bind(configValues.SectionKey, configValues);
            }

            return configValues;
        }
    }
}