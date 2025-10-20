using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autonomus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrestadorFiltroController : ControllerBase
    {

        [HttpGet("ObterPrestadorPorEstado")]
        public List<Prestador> FiltrarPorCidade([FromQuery] string? estado)
        {
            PrestadorBO bo = new PrestadorBO();
            return bo.FiltrarPorEstado(estado);
        }

        [HttpGet("ObterPrestadorPorNome")]
        public List<Prestador> Filtrar([FromQuery] string? nome)
        {
            PrestadorBO bo = new PrestadorBO();
            return bo.FiltrarPrestadores(nome);
        }



        [HttpGet("{id}", Name = "ObterPrestadorPorId")]
        public ActionResult<Prestador> GetById(int id)
        {
            PrestadorBO prestadores = new PrestadorBO();
            var prestador = prestadores.ObterPrestadorPorId(id);

            if (prestador == null)
            {
                return NotFound();
            }
            return Ok(prestador);
        }


    }
}
