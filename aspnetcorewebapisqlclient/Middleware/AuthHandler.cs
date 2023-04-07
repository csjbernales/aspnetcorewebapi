using System.Diagnostics;

namespace Gateway.Middleware
{
    public class AuthHandler
    {
        private readonly RequestDelegate next;

        public AuthHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var claims = context.User.Claims;

            var claim = claims.FirstOrDefault();

            if (claim != null) //add logic here
            {
                await this.next(context);
            }
            else
            {
                Debug.WriteLine("Authentication failed"); //add logic here
                //also add auth for swaggertest specific
            }
        }
    }
}