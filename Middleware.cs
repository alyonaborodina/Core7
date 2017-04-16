using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core7
{
    public class Middleware
    {

        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var Middle = context.Request.Query["Middle"];
            if (string.IsNullOrWhiteSpace(Middle) || Middle != "Middleware")
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Middle is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}

