using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Autonomus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteFiltroController : ControllerBase
    {

        [HttpGet("ObterClientesPorRating")]
        public List<Cliente> GetObterClientesPorRating(decimal avaliacaominima, decimal avaliacaomaxima)
        {
            ClienteBO clientes = new ClienteBO();
            return clientes.ObterClientesPorRating(avaliacaominima, avaliacaomaxima);
        }


        [HttpGet("ObterClientesPorNome")]
        public List<Cliente> Filtrar([FromQuery] string? nome)
        {
            ClienteBO bo = new ClienteBO();
            return bo.FiltrarClientes(nome);
        }

        [HttpGet("ObterClientesPorEstado")]
        public List<Cliente> FiltrarPorEstado([FromQuery] string? estado)
        {
            ClienteBO bo = new ClienteBO();
            return bo.FiltrarPorEstado(estado);
        }


        [HttpGet("{id}", Name = "ObterClientePorId")]
        public ActionResult<Cliente> GetById(int id)
        {
            ClienteBO clientes = new ClienteBO();
            var cliente = clientes.ObterClientePorId(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }


    }
}
