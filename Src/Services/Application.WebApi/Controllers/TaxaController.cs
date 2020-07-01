using System.Threading.Tasks;
using Juros.Application.TaxaJuros.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApi.Controllers
{
   public class TaxaController : BaseController
    {
        public TaxaController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Retorna valor taxa de juro
        /// </summary>
        /// <returns></returns>
        [HttpGet("taxajuros")]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetTaxaJurosCommand());

            return Ok(result.ValorTaxa);
        }
    }
}
