using aspnetcorewebapisqlclient.Middleware;

using Microsoft.AspNetCore.Http;

namespace aspnetcorewebapisqlclientTests.Middleware
{
    [TestClass()]
    public class ExceptionHandlerTests
    {
        private HttpContext httpContext;
        private RequestDelegate requestDelegate;

        [TestInitialize]
        public void Setup()
        {
            httpContext = A.Fake<HttpContext>();
            requestDelegate = A.Fake<RequestDelegate>();
        }

        [TestMethod()]
        public async Task InvokeFailTest()
        {
            try
            {
                ExceptionHandler exceptionHandler = new(next: (innerHttpContext) =>
                {
                    throw new Exception("Test");
                });

                var context = new DefaultHttpContext();
                context.Response.Body = new MemoryStream();

                await exceptionHandler.Invoke(context);
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<InvalidOperationException>();
            }
        }

        [TestMethod()]
        public async Task InvokeTest()
        {
            ExceptionHandler exceptionHandler = new(requestDelegate);
            await exceptionHandler.Invoke(httpContext);
        }
    }
}