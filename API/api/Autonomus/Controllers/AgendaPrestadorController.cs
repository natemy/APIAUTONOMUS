using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autonomus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaPrestadorController : ControllerBase
    {
        [HttpPost(Name = "InserirAgendaPrestador")]
        public decimal Post(AgendaPrestador agenda)
        {
            AgendaPrestadorBO agendas = new AgendaPrestadorBO();
            return agendas.InserirAgendaPrestador(agenda);
        }

        [HttpDelete(Name = "DeletarTudoAgendaPrestador")]
        public void Delete(int idPrestador)
        {
            AgendaPrestadorBO agendas = new AgendaPrestadorBO();
            agendas.DeletarTudoAgendaPrestador(idPrestador);
        }

        [HttpGet("{id}", Name = "ObterAgendaPrestadorPorId")]
        public ActionResult<AgendaPrestador> GetById(int id)
        {
            AgendaPrestadorBO agendas = new AgendaPrestadorBO();
            var agenda = agendas.ObterAgendaPrestadorPorId(id);

            if (agenda == null)
            {
                return NotFound();
            }
            return Ok(agenda);
        }
    }
}
