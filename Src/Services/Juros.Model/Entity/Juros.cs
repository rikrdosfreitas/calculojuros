using System.Linq;
using Juros.Common.Extensions;
using Juros.Common.Validation;

namespace Juros.Domain.Entity
{
    public class Juros
    {
        public Juros(decimal valorInicial, int tempo, decimal percentualJuros)
        {
            ValorInicial = valorInicial;
            Tempo = tempo;
            PercentualJuros = percentualJuros;
        }

        public decimal ValorInicial { get; private set; }

        public int Tempo { get; private set; }

        public decimal PercentualJuros { get; private set; }

        public static Juros Create(decimal valorInicial, int tempo, decimal valorJuros)
        {
            Guard.Validate(guard =>
                guard
                    .Min(valorInicial, 0m, nameof(valorInicial), "Valor inicial deve ser maior que zero!")
                    .Min(tempo, 0m, nameof(tempo), "Tempo deve ser maior que zero!")
                    .Min(valorJuros, 0m, nameof(valorJuros), "Valor juros deve ser maior que zero!")
            );

            return new Juros(valorInicial, tempo, valorJuros);
        }

        public decimal GetValorPeriodo()
        {
            var valorTaxa = Enumerable.Repeat((1 + PercentualJuros), Tempo).Aggregate((a, b) => a * b);

            var valorFinal = (ValorInicial * valorTaxa);

            return valorFinal.Truncate(2);
        }
    }
}
