using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Middlewares
{
    public class AccessKeyCheck
    {
        //Client Request sırasında onu temsil eden yapıdır.
        private readonly RequestDelegate _next;
        public AccessKeyCheck(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var client_id = context.Request.Headers.Keys.Contains("client-id");
            var app_id = context.Request.Headers.Keys.Contains("app-id");
            var secret_key = context.Request.Headers.Keys.Contains("secret-key");

            if (!client_id || !app_id || !secret_key)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Missing requested information!!!");
                return;
            }
            else
            {
                //Tüm bilgiler sağlanırsa.
            }

            //Sıradaki middleware yapısını çağırır.
            await _next.Invoke(context);
        }
    }
}
