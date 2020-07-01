using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Juros.Application.TaxaJuros.Commands
{
    public class GetTaxaJurosCommand : IRequest<TaxaJurosViewModel>
    {
        public GetTaxaJurosCommand()
        {
            
        }
    }

    class GetTaxaJurosCommandHandler : IRequestHandler<GetTaxaJurosCommand, TaxaJurosViewModel>
    {
        private readonly IMapper _mapper;

        public GetTaxaJurosCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<TaxaJurosViewModel> Handle(GetTaxaJurosCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<TaxaJurosViewModel>(Domain.Entity.TaxaJuros.Create());

            return await Task.FromResult(result);
        }
    }
}
