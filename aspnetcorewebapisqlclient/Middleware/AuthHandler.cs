using System.Diagnostics;

namespace aspnetcorewebapisqlclient.Middleware
{
    public class AuthHandler(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            var claims = context.User.Claims.ToList();

            var claim = claims.FirstOrDefault();

            if (claim is not null) //add checker here
            {
                await next(context);
            }
            else
            {
                Debug.WriteLine("Authentication failed"); //add logic here
                //also add auth for swaggertest specific
            }
        }
    }
}