using Microsoft.AspNetCore.Builder;

namespace SppdDocs.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="IApplicationBuilder" />
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        ///     Registers the global exception handler global exception handler.
        /// </summary>
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}