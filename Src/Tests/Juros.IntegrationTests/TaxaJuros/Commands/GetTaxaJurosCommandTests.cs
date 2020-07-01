using System.Threading.Tasks;
using FluentAssertions;
using Juros.Application.TaxaJuros.Commands;
using NUnit.Framework;

namespace Juros.Application.IntegrationTests.TaxaJuros.Commands
{
    using static Testing;

    [TestFixture()]
    public class GetTaxaJurosCommandTests
    {
        [Test()]
        public async Task GetTaxaJurosCommandTest()
        {
            var query = new GetTaxaJurosCommand();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.ValorTaxa.Should().Be(0.01m);
        }
    }
}