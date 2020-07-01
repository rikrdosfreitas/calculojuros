using System.Collections.Generic;
using FluentAssertions;
using Juros.Common.Validation;
using NUnit.Framework;

namespace Juros.Domain.UnitTests.Entity
{
    [TestFixture()]
    public class JurosTests
    {
        [Test()]
        public void DeveRetornarExcecaoValorInicialDeveSerMaiorQueZero()
        {
            var dictionary = new Dictionary<string, string[]>()
            {
                { "valorInicial", new []{ "Valor inicial deve ser maior que zero!" }},
            };

            FluentActions.Invoking(() => Domain.Entity.Juros.Create(0.0m, 5, 0.01m))
                .Should()
                .Throw<GuardValidationException>()
                .And.Errors.Should().BeEquivalentTo(dictionary);
        }

        [Test()]
        public void DeveRetornarExcecaoTempoDeveSerMaiorQueZero()
        {
            var dictionary = new Dictionary<string, string[]>()
            {
                { "tempo", new []{ "Tempo deve ser maior que zero!" }},
            };

            FluentActions.Invoking(() => Domain.Entity.Juros.Create(100.0m, 0, 0.01m))
                .Should()
                .Throw<GuardValidationException>()
                .And.Errors.Should().BeEquivalentTo(dictionary);
        }

        [Test()]
        public void DeveRetornarExcecaoValorJurosDeveSerMaiorQueZero()
        {

            var dictionary = new Dictionary<string, string[]>()
            {
                { "valorJuros", new []{ "Valor juros deve ser maior que zero!" }},
            };

            FluentActions.Invoking(() => Domain.Entity.Juros.Create(100.0m, 5, 0.00m))
                .Should()
                .Throw<GuardValidationException>()
                .And.Errors.Should().BeEquivalentTo(dictionary);
        }
        
        [Test()]
        public void DeveRetornarUmaNovaInstanciaDeJuros()
        {
            var juros = Domain.Entity.Juros.Create(100.0m, 5, 0.01m);

            juros.Should().NotBeNull();
            juros.ValorInicial.Should().Be(100.0m);
            juros.Tempo.Should().Be(5);
            juros.PercentualJuros.Should().Be(0.01m);
        }

        [Test()]
        public void DeveRetornarOValorDosJurosNoPeriodo()
        {
            var juros = Domain.Entity.Juros.Create(100.0m, 5, 0.01m);

            juros.GetValorPeriodo().Should().Be(105.10m);
        }
    }
}