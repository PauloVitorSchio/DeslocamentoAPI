using DeslocamentoApi.Application.Condutores.Commands.CriarCondutor;
using DeslocamentoApi.Application.Condutores.Queries.GetCondutores;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApi.WebAPI.Controllers
{
    public class CondutoresController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetCondutoresQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarCondutorCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
