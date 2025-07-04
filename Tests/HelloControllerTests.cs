using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class HelloControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public HelloControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_Hello_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/hello");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_Hello_ReturnsExpectedMessage()
        {
            // Act
            var response = await _client.GetAsync("/api/hello");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Hello, World!", content.Trim('"'));
        }
    }
}
