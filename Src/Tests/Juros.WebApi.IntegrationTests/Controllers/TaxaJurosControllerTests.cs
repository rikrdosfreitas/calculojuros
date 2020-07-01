using System.Threading.Tasks;
using Application.WebApi;
using Shouldly;
using Xunit;

namespace Juros.WebApi.IntegrationTests.Controllers
{
  
    public class TaxaJurosControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public TaxaJurosControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task TaxaJurosControllerTest()
        {
            var client = await _factory.GetClient();

            var response = await client.GetAsync($"/api/taxajuros");

            var responseMessage = response.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadAsStringAsync();

            result.ShouldBe("0.01");
        }
    }
}