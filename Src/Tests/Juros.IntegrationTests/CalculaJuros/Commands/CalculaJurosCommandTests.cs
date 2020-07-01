using System.Threading.Tasks;
using FluentAssertions;
using Juros.Application.CalculaJuros.Commands;
using NUnit.Framework;

namespace Juros.Application.IntegrationTests.CalculaJuros.Commands
{
    using static Testing;

    [TestFixture()]
    public class CalculaJurosCommandTests
    {
        [Test()]
        public async Task CalculaJurosCommandTest()
        {
            var command = new CalculaJurosCommand(100.0m, 5);

            var result = await SendAsync(command);

            result.Should().Be(105.10m);
        }
    }
}