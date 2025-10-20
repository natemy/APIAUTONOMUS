using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autonomus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoPrestadorController : ControllerBase
    {
        [HttpPost(Name = "InserirPublicacaoPrestador")]
        public void Post(PublicacaoPrestadorCompleta publicacao)
        {
            PublicacaoPrestadorBO publicacaoPrestadorBO = new PublicacaoPrestadorBO();
            PublicacaoPrestadorAbordagemBO publicacaoPrestadorAbordagemBO = new PublicacaoPrestadorAbordagemBO();
            PublicacaoPrestadorExperienciasBO publicacaoPrestadorExperienciasBO = new PublicacaoPrestadorExperienciasBO();
            PublicacaoPrestadorHabilidadesBO publicacaoPrestadorHabilidadesBO = new PublicacaoPrestadorHabilidadesBO();
            PublicacaoPrestadorQualidadesBO publicacaoPrestadorQualidadesBO = new PublicacaoPrestadorQualidadesBO();
            PublicacaoPrestadorSubcategoriaBO publicacaoPrestadorSubcategoriaBO = new PublicacaoPrestadorSubcategoriaBO();

            decimal idPublicacao = publicacaoPrestadorBO.InserirPublicacaoPrestador(publicacao.PublicacaoPrestador);
            foreach(var item in publicacao.PublicacaoPrestadorAbordagens)
            {
                item.IdPublicacaoPrestador = Convert.ToInt32(idPublicacao);
                publicacaoPrestadorAbordagemBO.InserirAbordagemPrestador(item);
            }
            foreach (var item in publicacao.PublicacaoPrestadorExperiencias)
            {
                item.IdPublicacaoPrestador = Convert.ToInt32(idPublicacao);
                publicacaoPrestadorExperienciasBO.InserirExperienciaPrestador(item);
            }
            foreach (var item in publicacao.PublicacaoPrestadorHabilidades)
            {
                item.IdPublicacaoPrestador = Convert.ToInt32(idPublicacao);
                publicacaoPrestadorHabilidadesBO.InserirHabilidadePrestador(item);
            }
            foreach (var item in publicacao.PublicacaoPrestadorQualidades)
            {
                item.IdPublicacaoPrestador = Convert.ToInt32(idPublicacao);
                publicacaoPrestadorQualidadesBO.InserirQualidadesPrestador(item);
            }
            foreach (var item in publicacao.PublicacaoPrestadorSubcategorias)
            {
                item.IdPublicacaoPrestador = Convert.ToInt32(idPublicacao);
                publicacaoPrestadorSubcategoriaBO.InserirSubcategoriaPrestador(item);
            }
        }

        [HttpPut(Name = "AtualizarPublicacaoPrestador")]
        public void Put(PublicacaoPrestadorCompleta publicacao)
        {
            PublicacaoPrestadorBO publicacaoPrestadorBO = new PublicacaoPrestadorBO();
            PublicacaoPrestadorAbordagemBO publicacaoPrestadorAbordagemBO = new PublicacaoPrestadorAbordagemBO();
            PublicacaoPrestadorExperienciasBO publicacaoPrestadorExperienciasBO = new PublicacaoPrestadorExperienciasBO();
            PublicacaoPrestadorHabilidadesBO publicacaoPrestadorHabilidadesBO = new PublicacaoPrestadorHabilidadesBO();
            PublicacaoPrestadorQualidadesBO publicacaoPrestadorQualidadesBO = new PublicacaoPrestadorQualidadesBO();
            PublicacaoPrestadorSubcategoriaBO publicacaoPrestadorSubcategoriaBO = new PublicacaoPrestadorSubcategoriaBO();

            publicacaoPrestadorBO.AtualizarPublicacaoPrestador(publicacao.PublicacaoPrestador);
            publicacaoPrestadorBO.DeletarPublicacaoPrestadorRelacoes(publicacao.PublicacaoPrestador);
            decimal idPublicacao = publicacao.PublicacaoPrestador.IdPublicacaoPrestador;
            foreach (var item in publicacao.PublicacaoPrestadorAbordagens)
            {
                item.IdPublicacaoPrestador = Convert.ToInt32(idPublicacao);
                publicacaoPrestadorAbordagemBO.InserirAbordagemPrestador(item);
            }
            foreach (var item in publicacao.PublicacaoPrestadorExperiencias)
            {
                item.IdPublicacaoPrestador = Convert.ToInt32(idPublicacao);
                publicacaoPrestadorExperienciasBO.InserirExperienciaPrestador(item);
            }
            foreach (var item in publicacao.PublicacaoPrestadorHabilidades)
            {
                item.IdPublicacaoPrestador = Convert.ToInt32(idPublicacao);
                publicacaoPrestadorHabilidadesBO.InserirHabilidadePrestador(item);
            }
            foreach (var item in publicacao.PublicacaoPrestadorQualidades)
            {
                item.IdPublicacaoPrestador = Convert.ToInt32(idPublicacao);
                publicacaoPrestadorQualidadesBO.InserirQualidadesPrestador(item);
            }
            foreach (var item in publicacao.PublicacaoPrestadorSubcategorias)
            {
                item.IdPublicacaoPrestador = Convert.ToInt32(idPublicacao);
                publicacaoPrestadorSubcategoriaBO.InserirSubcategoriaPrestador(item);
            }
        }
    }
}
