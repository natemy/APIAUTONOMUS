using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Autonomus.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Autonomus.Business
{
    public class PublicacaoPrestadorSubcategoriaBO
    {
        public List<PublicacaoPrestadorSubcategoria> ObterSubcategoriaPrestador()
        {
            using var contexto = new Context();
            var resultado = contexto.PublicacaoPrestadorSubcategoria
                .FromSqlRaw("exec sp_ObterSubcategoriaPrestador");

            return resultado.ToList();
        }

        public decimal InserirSubcategoriaPrestador(PublicacaoPrestadorSubcategoria subcategoria)
        {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@IdPublicacaoPrestador", subcategoria.IdPublicacaoPrestador),
                new SqlParameter("@SubcategoriaPrestador", subcategoria.SubcategoriaPrestador ?? (object)DBNull.Value)
            };

            var resultado = contexto
                .Set<NovoSubcategoriaPrestadorResultado>()
                .FromSqlRaw("EXEC sp_InserirSubcategoriaPrestador @IdPublicacaoPrestador, @SubcategoriaPrestador", parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdSubcategoriaPrestador ?? 0;
        }

        public void DeletarSubcategoriaPrestador(int IdSubcategoriaPrestador)
        {
            var contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@IdSubcategoria", IdSubcategoriaPrestador)
            };

            contexto.Database.ExecuteSqlRaw("EXEC dboDeletarSubcategoriaPrestador @IdSubcategoria", parametros);
        }
    }
}
