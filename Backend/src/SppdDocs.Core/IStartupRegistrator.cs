﻿using System;

using Microsoft.Extensions.DependencyInjection;

namespace SppdDocs.Core
{
    /// <summary>
    ///     Implement this interface to register dependencies and/or serviceCollection during application startup. Note that
    ///     classes implementing this interface will be called automatically.
    /// </summary>
    public interface IStartupRegistrator
    {
        /// <summary>
        ///     Gets the priority. <see cref="IStartupRegistrator" /> with a higher priority will be executed first
        /// </summary>
        int Priority { get; }

        /// <summary>
        ///     Register services on the serviceCollection, when called.
        /// </summary>
        /// <param name="serviceCollection">The serviceCollection.</param>
        void RegisterService(IServiceCollection serviceCollection);

        /// <summary>
        ///     Configures your services.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        void ConfigureService(IServiceProvider serviceProvider);
    }
}