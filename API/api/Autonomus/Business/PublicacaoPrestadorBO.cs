using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Autonomus.Business
{
    public class PublicacaoPrestadorBO
    {
        public decimal InserirPublicacaoPrestador(PublicacaoPrestador publicacao)
        {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@IdPrestador", publicacao.IdPrestador),
                new SqlParameter("@CategoriaPrestador", publicacao.CategoriaPublicacaoPrestador ?? (object)DBNull.Value),
                new SqlParameter("@DescricaoPublicacaoPrestador", publicacao.DescricaoPublicacaoPrestador ?? (object)DBNull.Value),
                new SqlParameter("@ValorPrestador", publicacao.ValorPublicacaoPrestador),
                new SqlParameter("@FormaDeAtendimentoPrestador", publicacao.FormaDeAtendimentoPrestador ?? (object)DBNull.Value),
                new SqlParameter("@DataPublicacaoPrestador", publicacao.DataPublicacaoPrestador)
            };

            var resultado = contexto
                .Set<NovoPublicacaoPrestadorResultado>()
                .FromSqlRaw("EXEC sp_InserirPublicacaoPrestador @IdPrestador, @CategoriaPrestador, @DescricaoPublicacaoPrestador, @ValorPrestador, @FormaDeAtendimentoPrestador, @DataPublicacaoPrestador", parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdPrestadorPublicacao ?? 0;
        }


        public void DeletarPublicacaoPrestadorRelacoes(PublicacaoPrestador publicacao)
        {
            using Context contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@IdPublicacaoPrestador", publicacao.IdPublicacaoPrestador),
            };

            contexto.Database.ExecuteSqlRaw(
                "EXEC sp_DeletaRelacionamentosPublicacaoPrestador @IdPublicacaoPrestador",
                parametros
            );
        }


        public void AtualizarPublicacaoPrestador(PublicacaoPrestador publicacao)
        {
            using Context contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@IdPublicacaoPrestador", publicacao.IdPublicacaoPrestador),
                new SqlParameter("@CategoriaPrestador", publicacao.CategoriaPublicacaoPrestador ?? (object)DBNull.Value),
                new SqlParameter("@DescricaoPublicacaoPrestador", publicacao.DescricaoPublicacaoPrestador ?? (object)DBNull.Value),
                new SqlParameter("@ValorPrestador", publicacao.ValorPublicacaoPrestador),
                new SqlParameter("@FormaDeAtendimentoPrestador", publicacao.FormaDeAtendimentoPrestador ?? (object)DBNull.Value)
            };

            contexto.Database.ExecuteSqlRaw(
                "EXEC sp_UpdatePublicacaoPrestador @IdPublicacaoPrestador, @CategoriaPrestador, @DescricaoPublicacaoPrestador, @ValorPrestador, @FormaDeAtendimentoPrestador",
                parametros
            );
        }
    }
}
