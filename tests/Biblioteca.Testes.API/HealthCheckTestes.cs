using Biblioteca.API;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Biblioteca.Testes.API
{
    public class HealthCheckTestes
    {
        protected HttpClient Client;

        [OneTimeSetUp]
        public void ExecutaAntesDeTodosOsTestes()
        {
            var hostBuilder = new WebApplicationFactory<Startup>();
            Client = hostBuilder.CreateDefaultClient();
        }

        [Test]
        public async Task DeveRetornarHealthy()
        {
            var response = await Client.GetAsync("health");

            var content = await response.Content.ReadAsStringAsync();

            content.Should().NotBeNullOrEmpty();
            content.Should().Be("Healthy");
        }
    }
}