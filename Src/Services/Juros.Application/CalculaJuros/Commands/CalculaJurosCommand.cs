using System.Threading;
using System.Threading.Tasks;
using Juros.Application.Service;
using MediatR;

namespace Juros.Application.CalculaJuros.Commands
{
    public class CalculaJurosCommand : IRequest<decimal>
    {
        public CalculaJurosCommand(decimal valorInicial, int tempo)
        {
            ValorInicial = valorInicial;
            Tempo = tempo;
        }

        public decimal ValorInicial { get; set; }

        public int Tempo { get; set; }

    }

    class CalculaJurosCommandHandler : IRequestHandler<CalculaJurosCommand,decimal>
    {
        private readonly IApiService _apiService;

        public CalculaJurosCommandHandler(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<decimal> Handle(CalculaJurosCommand request, CancellationToken cancellationToken)
        {
            var taxaJuros = await _apiService.GetTaxaJuros();

            var result = Domain.Entity.Juros.Create(request.ValorInicial, request.Tempo, taxaJuros);

            return result.GetValorPeriodo();
        }
    }
}
