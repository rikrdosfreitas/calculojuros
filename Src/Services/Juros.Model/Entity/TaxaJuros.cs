namespace Juros.Domain.Entity
{
    public class TaxaJuros
    {
        public TaxaJuros(decimal valorTaxa)
        {
            ValorTaxa = valorTaxa;
        }

        public decimal ValorTaxa { get; private set; }

        public static TaxaJuros Create()
        {
            return new TaxaJuros(0.01m);
        }
    }
}
