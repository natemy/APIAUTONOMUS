using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autonomus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosCompativeisController : ControllerBase
    {
        [HttpGet(Name = "ObterHorariosCompativeis")]
        public List<AgendaPrestador> Get(int idPrestador, int idCliente)
        {
            HorariosCompativeisBO agenda = new HorariosCompativeisBO();
            return agenda.ObterHorariosCompativeis(idPrestador, idCliente);
        }
    }
}
