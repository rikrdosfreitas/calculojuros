using System.Threading.Tasks;
using Juros.Application.CalculaJuros.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApi.Controllers
{
 public class JurosController : BaseController
    {
        public JurosController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Retorna resultado do calculo de juros
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="meses"></param>
        /// <returns></returns>
        [HttpGet("calculajuros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Get(decimal valorInicial, int meses)
        {
            var result = await Mediator.Send(new CalculaJurosCommand(valorInicial, meses));

            return Ok(result);
        }

        /// <summary>
        /// Retorna url do projeto no github
        /// </summary>
        /// <returns></returns>
        [HttpGet("showmethecode")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult ShowmeTheCode()
        {
            return Ok("https://github.com/rikrdosfreitas/calculojuros");
        }

    }
}
