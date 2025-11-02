using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autonomus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaClienteController : ControllerBase
    {
        [HttpPost(Name = "InserirAgendaCliente")]
        public decimal Post(AgendaCliente agenda)
        {
            AgendaClienteBO agendas = new AgendaClienteBO();
            return agendas.InserirAgendaCliente(agenda);
        }

        [HttpDelete(Name = "DeletarTudoAgendaCliente")]
        public void Delete(int idCliente)
        {
            AgendaClienteBO agendas = new AgendaClienteBO();
            agendas.DeletarTudoAgendaCliente(idCliente);
        }

        [HttpGet("{id}", Name = "ObterAgendaClientePorId")]
        public ActionResult<AgendaCliente> GetById(int id)
        {
            AgendaClienteBO agendas = new AgendaClienteBO();
            var agenda = agendas.ObterAgendaClientePorId(id);

            if (agenda == null)
            {
                return NotFound();
            }
            return Ok(agenda);
        }
    }
}
