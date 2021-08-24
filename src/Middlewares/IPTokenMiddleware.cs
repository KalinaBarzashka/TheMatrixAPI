namespace TheMatrixAPI.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading.Tasks;
    using TheMatrixAPI.Models.DbModels;
    using TheMatrixAPI.Services;

    public class IPTokenMiddleware : IMiddleware
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IIPTokenMiddlewareService iPTokenMiddlewareService;

        public IPTokenMiddleware(UserManager<ApplicationUser> userManager, IIPTokenMiddlewareService iPTokenMiddlewareService)
        {
            this.userManager = userManager;
            this.iPTokenMiddlewareService = iPTokenMiddlewareService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var method = context.Request.Method;
            if(method == "POST")
            {
                var requestTokenId = context.Request.Form["tokenId"].ToString();
                if (!this.iPTokenMiddlewareService.IsTokenValid(requestTokenId))
                {
                    throw new Exception("Invalid token!");
                }

                try
                {
                    this.iPTokenMiddlewareService.AddRecordByTokenId(requestTokenId, DateTime.UtcNow.ToString("dd/MM/yyyy"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (method == "GET")
            {
                if (context.Request.Path.StartsWithSegments("/api"))
                {
                    var ip = context.Connection.RemoteIpAddress?.MapToIPv4().ToString();
                    if (ip == "0.0.0.1")
                    {
                        ip = "127.0.0.1";
                    }

                    var user = await this.userManager.GetUserAsync(context.User);

                    try
                    {
                        if (user != null)
                        {
                            var tokenId = user.TokenId;
                            this.iPTokenMiddlewareService.AddRecordByTokenId(tokenId, DateTime.UtcNow.ToString("dd/MM/yyyy"));
                        }
                        else
                        {
                            this.iPTokenMiddlewareService.AddRecordByIp(ip, DateTime.UtcNow.ToString("dd/MM/yyyy"));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            
            

            await next(context);
        }
    }
}
