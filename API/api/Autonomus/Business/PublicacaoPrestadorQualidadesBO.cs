using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Autonomus.Business
{
    public class PublicacaoPrestadorQualidadesBO
    {

        public List<PublicacaoPrestadorQualidades> ObterQualidadesPrestador()
        {
            using var contexto = new Context();
            var resultado = contexto.Set<PublicacaoPrestadorQualidades>()
                .FromSqlRaw("EXEC sp_ObterQualidadesPrestador");

            return resultado.ToList();
        }


        public decimal InserirQualidadesPrestador(PublicacaoPrestadorQualidades qualidade)
        {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@IdPublicacaoPrestador", qualidade.IdPublicacaoPrestador),
                new SqlParameter("@DescricaoQualidadePrestador", qualidade.DescricaoQualidadePrestador ?? (object)DBNull.Value)
            };

            var resultado = contexto
                .Set<NovoQualidadePrestadorResultado>()
                .FromSqlRaw("EXEC sp_InserirQualidadePrestador @IdPublicacaoPrestador, @DescricaoQualidadePrestador", parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdPrestadorQualidade ?? 0;
        }

        public void DeletarQualidadesPrestador(int IdQualidadePrestador)
        {
            var contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@IdQualidade", IdQualidadePrestador)
            };

            contexto.Database.ExecuteSqlRaw("EXEC sp_DeletarQualidadePrestador @IdQualidade ", parametros);
        }
    }
}
