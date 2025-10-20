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
        [HttpDelete(Name = "DeletarPublicacaoPrestador")]
        public void Delete(decimal idPrestador)
        {
            PublicacaoPrestadorBO publicacaoPrestadorBO = new PublicacaoPrestadorBO();
            PublicacaoPrestadorAbordagemBO publicacaoPrestadorAbordagemBO = new PublicacaoPrestadorAbordagemBO();
            PublicacaoPrestadorExperienciasBO publicacaoPrestadorExperienciasBO = new PublicacaoPrestadorExperienciasBO();
            PublicacaoPrestadorHabilidadesBO publicacaoPrestadorHabilidadesBO = new PublicacaoPrestadorHabilidadesBO();
            PublicacaoPrestadorQualidadesBO publicacaoPrestadorQualidadesBO = new PublicacaoPrestadorQualidadesBO();
            PublicacaoPrestadorSubcategoriaBO publicacaoPrestadorSubcategoriaBO = new PublicacaoPrestadorSubcategoriaBO();

            // 1️⃣ Deleta primeiro as dependências
            publicacaoPrestadorAbordagemBO.DeletarAbordagemPrestador(Convert.ToInt32(idPrestador));
            publicacaoPrestadorExperienciasBO.DeletarExperienciaPrestador(Convert.ToInt32(idPrestador));
            publicacaoPrestadorHabilidadesBO.DeletarHabilidadePrestador(Convert.ToInt32(idPrestador));
            publicacaoPrestadorQualidadesBO.DeletarQualidadesPrestador(Convert.ToInt32(idPrestador));
            publicacaoPrestadorSubcategoriaBO.DeletarSubcategoriaPrestador(Convert.ToInt32(idPrestador));

            // 2️⃣ Por fim, deleta a publicação principal
            publicacaoPrestadorBO.DeletarPublicacaoPrestador(Convert.ToInt32(idPrestador));
        }


        [HttpGet(Name = "ObterTodasPublicacoesPrestador")]
        public ActionResult<List<PublicacaoPrestadorCompleta>> Get()
        {
            PublicacaoPrestadorBO publicacaoPrestadorBO = new PublicacaoPrestadorBO();
            PublicacaoPrestadorAbordagemBO publicacaoPrestadorAbordagemBO = new PublicacaoPrestadorAbordagemBO();
            PublicacaoPrestadorExperienciasBO publicacaoPrestadorExperienciasBO = new PublicacaoPrestadorExperienciasBO();
            PublicacaoPrestadorHabilidadesBO publicacaoPrestadorHabilidadesBO = new PublicacaoPrestadorHabilidadesBO();
            PublicacaoPrestadorQualidadesBO publicacaoPrestadorQualidadesBO = new PublicacaoPrestadorQualidadesBO();
            PublicacaoPrestadorSubcategoriaBO publicacaoPrestadorSubcategoriaBO = new PublicacaoPrestadorSubcategoriaBO();

            List<PublicacaoPrestador> publicacoesPrincipais = publicacaoPrestadorBO.ObterPublicacaoPrestador();

            List<PublicacaoPrestadorAbordagem> todasAbordagens = publicacaoPrestadorAbordagemBO.ObterAbordagemPrestador();
            List<PublicacaoPrestadorExperiencias> todasExperiencias = publicacaoPrestadorExperienciasBO.ObterExperienciasPrestador();
            List<PublicacaoPrestadorHabilidades> todasHabilidades = publicacaoPrestadorHabilidadesBO.ObterHabilidadesPrestador();
            List<PublicacaoPrestadorQualidades> todasQualidades = publicacaoPrestadorQualidadesBO.ObterQualidadesPrestador();
            List<PublicacaoPrestadorSubcategoria> todasSubcategorias = publicacaoPrestadorSubcategoriaBO.ObterSubcategoriaPrestador();

            List<PublicacaoPrestadorCompleta> publicacoesCompletas = new List<PublicacaoPrestadorCompleta>();

            foreach (var pubPrincipal in publicacoesPrincipais)
            {
                int idPublicacao = Convert.ToInt32(pubPrincipal.IdPublicacaoPrestador);

                PublicacaoPrestadorCompleta publicacaoCompleta = new PublicacaoPrestadorCompleta
                {
                    PublicacaoPrestador = pubPrincipal,
                    PublicacaoPrestadorAbordagens = todasAbordagens
                        .Where(a => a.IdPublicacaoPrestador == idPublicacao).ToList(),

                    PublicacaoPrestadorExperiencias = todasExperiencias
                        .Where(e => e.IdPublicacaoPrestador == idPublicacao).ToList(),

                    PublicacaoPrestadorHabilidades = todasHabilidades
                        .Where(h => h.IdPublicacaoPrestador == idPublicacao).ToList(),

                    PublicacaoPrestadorQualidades = todasQualidades
                        .Where(q => q.IdPublicacaoPrestador == idPublicacao).ToList(),

                    PublicacaoPrestadorSubcategorias = todasSubcategorias
                        .Where(s => s.IdPublicacaoPrestador == idPublicacao).ToList()
                };

                publicacoesCompletas.Add(publicacaoCompleta);
            }
            return Ok(publicacoesCompletas);
        }
    }
}
