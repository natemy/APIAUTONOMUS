using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Autonomus.Business
{
    public class PublicacaoPrestadorAbordagemBO
    {
        public decimal InserirAbordagemPrestador(PublicacaoPrestadorAbordagem abordagem)
        {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@IdPublicacaoPrestador", abordagem.IdPublicacaoPrestador),
                new SqlParameter("@DescricaoAbordagemPrestador", abordagem.DescricaoAbordagemPrestador ?? (object)DBNull.Value)
            };

            var resultado = contexto
                .Set<NovoAbordagemPrestadorResultado>()
                .FromSqlRaw("EXEC sp_InserirAbordagemPrestador @IdPublicacaoPrestador, @DescricaoAbordagemPrestador", parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdPrestadorAbordagem ?? 0;
        }
    }
}
