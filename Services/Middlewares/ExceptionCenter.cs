using Microsoft.AspNetCore.Http;
using Serilog;
using Services.Middlewares.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.Middlewares
{
    public class ExceptionCenter
    {
        private readonly RequestDelegate _next;
        private static readonly ILogger logger = Serilog.Log.ForContext<ExceptionCenter>();
        public ExceptionCenter(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            logger.Error($"{DateTime.Now.ToShortDateString()} : {ex}");
            return context.Response.WriteAsync(new ExceptionResponseModel
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
                StackTrace = ex.StackTrace
            }.ToString());
        }
    }
}
