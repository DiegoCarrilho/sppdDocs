using System;
using System.Reflection;
using System.Threading.Tasks;

using log4net;

using Microsoft.AspNetCore.Http;

namespace SppdDocs
{
    /// <summary>
    ///     Logs and rethrows all uncaught exceptions
    /// </summary>
    public class GlobalExceptionHandlerMiddleware
    {
        private static readonly ILog s_logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                s_logger.Error("An unhandled exception has been caught", e);
                throw;
            }
        }
    }
}