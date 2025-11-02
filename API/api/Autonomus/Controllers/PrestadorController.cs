using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Autonomus.Controllers
{
    [ApiController]
    [Route("[controller]")]
     public class PrestadorController: ControllerBase
        {

        [HttpGet(Name = "ObterPrestador")]
        public List<Prestador> Get()
        {
            PrestadorBO prestador = new PrestadorBO();
            return prestador.ObterPrestador();
        }


        [HttpPost(Name = "InserirPrestador")]
        public decimal Post(Prestador prestador)
        {
            return PrestadorBO.InserirPrestador(prestador);
        }

        [HttpDelete(Name = "DeletarPrestador")]
        public void Delete(int idPrestador)
        {
            PrestadorBO prestador = new PrestadorBO();
            prestador.DeletarPrestador(idPrestador);
        }


        [HttpPut(Name = "AtualizarPrestador")]
        public void Put(Prestador prestador) => PrestadorBO.AtualizarPrestador(prestador);




    }
}

