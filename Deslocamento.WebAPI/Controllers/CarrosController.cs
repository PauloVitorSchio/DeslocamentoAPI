using DeslocamentoApi.Application.Carros.Commands.CriarCarro;
using DeslocamentoApi.Application.Carros.Queries.GetCarros;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApi.WebAPI.Controllers
{
    public class CarrosController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetCarrosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarCarroCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
