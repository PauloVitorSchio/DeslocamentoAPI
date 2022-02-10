using DeslocamentoApi.Application.Deslocamentos.Commands.FinalizarDeslocamento;
using DeslocamentoApi.Application.Deslocamentos.Commands.IniciarDeslocamento;
using DeslocamentoApi.Application.Deslocamentos.Queries.GetDeslocamentos;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApi.WebAPI.Controllers
{
    public class DeslocamentosController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetDeslocamentosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] IniciarDeslocamentoCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{deslocamentoId:int}/finalizarDeslocamento")]
        public async Task<IActionResult> PutFinalizarDeslocamentoAsync(
            [FromRoute] int deslocamentoId,
            [FromBody] FinalizarDeslocamentoCommand command)
        {
            if (deslocamentoId != command.Id) return BadRequest();

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
