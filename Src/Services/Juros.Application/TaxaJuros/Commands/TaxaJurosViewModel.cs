using Juros.Application.Common.Mappings;

namespace Juros.Application.TaxaJuros.Commands
{
    public class TaxaJurosViewModel : IMapFrom<Domain.Entity.TaxaJuros>
    {
        public decimal ValorTaxa { get; set; }
    }
}