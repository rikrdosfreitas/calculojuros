using FluentAssertions;
using NUnit.Framework;

namespace Juros.Domain.UnitTests.Entity
{
    [TestFixture()]
    public class TaxaJurosTests
    {
        [Test()]
        public void CreateTest()
        {
            var taxaJuros = Domain.Entity.TaxaJuros.Create();

            taxaJuros.Should().NotBeNull();
            taxaJuros.ValorTaxa.Should().Be(0.01m);
        }
    }
}