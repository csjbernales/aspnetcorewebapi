using System.Security.Authentication;

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
            var claims = context.User.Claims.ToList();
            var issuer = claims.First().Issuer;


            if (issuer == null)
            {
                throw new AuthenticationException();//todo: add errormodel and condition here for valid authentication
            }

            await this.next(context);
        }
    }
}