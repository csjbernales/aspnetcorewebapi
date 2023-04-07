namespace aspnetcorewebapisqlclient.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;

        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
