using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Autonomus.Business
{
    public class PublicacaoPrestadorExperienciasBO
    {

        public List<PublicacaoPrestadorExperiencias> ObterExperienciasPrestador()
        {
            using var contexto = new Context();
            var resultado = contexto.Set<PublicacaoPrestadorExperiencias>()
                .FromSqlRaw("EXEC sp_ObterExperienciasPrestador");

            return resultado.ToList();
        }

        public decimal InserirExperienciaPrestador(PublicacaoPrestadorExperiencias experiencia)
        {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@IdPublicacaoPrestador", experiencia.IdPublicacaoPrestador),
                new SqlParameter("@DescricaoExperienciaPrestador", experiencia.DescricaoExperienciaPrestador ?? (object)DBNull.Value)
            };

            var resultado = contexto
                .Set<NovoExperienciaPrestadorResultado>()
                .FromSqlRaw("EXEC sp_InserirExperienciaPrestador @IdPublicacaoPrestador, @DescricaoExperienciaPrestador", parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdPrestadorExperiencia ?? 0;
        }

        public void DeletarExperienciaPrestador(int IdExperienciaPrestador)
        {
            var contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@IdExperiencia", IdExperienciaPrestador)
            };

            contexto.Database.ExecuteSqlRaw("EXEC dboDeletarExperienciaPrestador @IdExperiencia", parametros);
        }

        public void AtualizaroExperienciaPrestador(PublicacaoPrestadorExperiencias experiencia)
        {
            using Context contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@IdExperiencia", experiencia.IdPublicacaoPrestadorExperiencia),
                new SqlParameter("@DescricaoExperienciaPrestador", experiencia.DescricaoExperienciaPrestador ?? (object)DBNull.Value)
            };

            contexto.Database.ExecuteSqlRaw(
                "EXEC sp_UpdateExperienciaPrestador @IdExperiencia, @DescricaoExperienciaPrestador",
                parametros
            );
        }

    }
}
