using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Autonomus.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Autonomus.Business
{
    public class AgendaPrestadorBO
    {

        public decimal InserirAgendaPrestador(AgendaPrestador agenda)
        {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@id_prestador", agenda.idPrestador),
                new SqlParameter("@diasemana", agenda.diaSemana),
                new SqlParameter("@horario", agenda.horario)
            };

            var resultado = contexto
                .Set<NovoAgendaPrestadorResultado>()
                .FromSqlRaw(
                    "EXEC sp_InserirAgendaPrestador @id_prestador, @diasemana, @horario",
                    parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdAgendaPrestador ?? 0;
        }

        public void DeletarTudoAgendaPrestador(int idPrestador)
        {
            var contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@idPrestador", idPrestador)
            };

            contexto.Database.ExecuteSqlRaw("EXEC sp_AtualizarAgendaPrestador @idPrestador", parametros);
        }

        public List<AgendaPrestador> ObterAgendaPrestadorPorId(int id)
        {
            Context contexto = new Context();
            var parametro = new SqlParameter("@IdPrestador", id);
            return contexto.AgendaPrestador
                .FromSqlRaw("exec sp_ObterAgendaPorPrestador @IdPrestador", parametro)
                .AsEnumerable().ToList();
        }




    }
}
