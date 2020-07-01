using System.Net;
using System.Threading.Tasks;
using Application.WebApi;
using Shouldly;
using Xunit;

namespace Juros.WebApi.IntegrationTests.Controllers
{
    public class CalculaJurosControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CalculaJurosControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task TaxaJurosControllerTest()
        {
            var client = await _factory.GetClient();
            
            var response = await client.GetAsync($"/api/calculajuros?valorinicial=100&meses=5");

            var responseMessage = response.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadAsStringAsync();

            result.ShouldBe("105.1");
        }


        [Fact()]
        public async Task TaxaJurosControllerTestReturnBadRequest()
        {
            var client = await _factory.GetClient();

            var response = await client.GetAsync($"/api/calculajuros?valorinicial=0&meses=5");

            response.StatusCode.ShouldBe(HttpStatusCode.UnprocessableEntity);
        }
    }
}
