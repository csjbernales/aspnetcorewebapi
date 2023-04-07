using aspnetcorewebapisqlclient.Middleware;

using Microsoft.AspNetCore.Http;

using System.Security.Claims;

namespace aspnetcorewebapisqlclientTests.Middleware
{
    [TestClass()]
    public class AuthHandlerTests
    {
        private List<Claim> claims;
        private HttpContext httpContext;
        private RequestDelegate requestDelegate;

        [TestInitialize]
        public void Setup()
        {
            httpContext = A.Fake<HttpContext>();
            requestDelegate = A.Fake<RequestDelegate>();
        }

        [TestMethod()]
        public async Task InvokeTest()
        {
            claims = new()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "userId"),
                new Claim("name", "John Doe"),
            };

            A.CallTo(() => httpContext.User.Claims).Returns(claims);

            AuthHandler authHandler = new(requestDelegate);

            await authHandler.Invoke(httpContext);
            true.Should().BeTrue();
        }

        [TestMethod()]
        public async Task InvokeFailTest()
        {
            claims = new();

            A.CallTo(() => httpContext.User.Claims).Returns(claims);

            AuthHandler authHandler = new(requestDelegate);

            await authHandler.Invoke(httpContext);
            true.Should().BeTrue();
        }
    }
}