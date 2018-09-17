using System;
using Microsoft.Extensions.DependencyInjection;

namespace SppdDocs.Core
{
	/// <summary>
	///     Implement this interface to register dependencies and/or serviceCollection during application startup. Note that
	///     classes
	///     implementing this interface will be called automatically.
	/// </summary>
	public interface IStartupRegistrator
	{
		/// <summary>
		///     Register services on the serviceCollection, when called.
		/// </summary>
		/// <param name="serviceCollection">The serviceCollection.</param>
		void RegisterService(IServiceCollection serviceCollection);

		void ConfigureService(IServiceProvider serviceProvider);
	}
}