namespace TheMatrixAPI.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class IPTokenMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var ip = context.Request.HttpContext.Connection.RemoteIpAddress;
            var user = context.User;

            
            await next(context);
        }
    }
}
