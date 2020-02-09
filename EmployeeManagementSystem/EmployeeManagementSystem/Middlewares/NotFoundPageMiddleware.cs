using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Middlewares
{
    public class NotFoundPageMiddleware
    {
        private readonly RequestDelegate next;

        public NotFoundPageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpcontext)
        {
            await this.next.Invoke(httpcontext);

            if (httpcontext.Response.StatusCode == 404)
            {
                httpcontext.Response.Redirect("/home/notfoundpage");
            }

        }
    }
}
