using DeslocamentoApi.Application.Clientes.Commands.CriarCliente;
using DeslocamentoApi.Application.Clientes.Queries.GetClientes;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApi.WebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetClientesQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarClienteCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
