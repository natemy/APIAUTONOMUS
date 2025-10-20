using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Autonomus.Entities.PublicacaoPrestadorHabilidades;

namespace Autonomus.Business
{
    public class PublicacaoPrestadorHabilidadesBO
    {
        public List<PublicacaoPrestadorHabilidades> ObterHabilidadesPrestador()
        {
            using var contexto = new Context();
            var resultado = contexto.Set<PublicacaoPrestadorHabilidades>()
                .FromSqlRaw("EXEC sp_ObterHabilidadesPrestador");

            return resultado.ToList();
        }

        public decimal InserirHabilidadePrestador(PublicacaoPrestadorHabilidades habilidade)
        {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@IdPublicacaoPrestador", habilidade.IdPublicacaoPrestador),
                new SqlParameter("@DescricaoHabilidadePrestador", habilidade.DescricaoHabilidadePrestador ?? (object)DBNull.Value)
            };

            var resultado = contexto
                .Set<NovoHabilidadePrestadorResultado>()
                .FromSqlRaw("EXEC sp_InserirHabilidadePrestador @IdPublicacaoPrestador, @DescricaoHabilidadePrestador", parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdPrestadorHabilidade ?? 0;
        }

        public void DeletarHabilidadePrestador(int idHabilidadePrestador)
        {
            using var contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@IdHabilidade", idHabilidadePrestador)
            };

            contexto.Database.ExecuteSqlRaw("EXEC sp_DeletarHabilidadePrestador @IdHabilidade", parametros);
        }

        public void AtualizarHabilidadePrestador(PublicacaoPrestadorHabilidades habilidade)
        {
            using Context contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@IdHabilidade", habilidade.IdPrestadorHabilidades),
                new SqlParameter("@DescricaoHabilidadePrestador", habilidade.DescricaoHabilidadePrestador ?? (object)DBNull.Value)
            };

            contexto.Database.ExecuteSqlRaw(
                "EXEC sp_UpdateHabilidadePrestador @IdHabilidade, @DescricaoHabilidadePrestador",
                parametros
            );
        }
    }
}
