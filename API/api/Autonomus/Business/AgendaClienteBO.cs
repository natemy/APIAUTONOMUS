using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Autonomus.Business
{
    public class AgendaClienteBO
    {
        public decimal InserirAgendaCliente(AgendaCliente agenda)
        {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@id_cliente", agenda.idCliente),
                new SqlParameter("@diasemana", agenda.diaSemana),
                new SqlParameter("@horario", agenda.horario)
            };

            var resultado = contexto
                .Set<NovoAgendaClienteResultado>()
                .FromSqlRaw(
                    "EXEC sp_InserirAgendaCliente @id_cliente, @diasemana, @horario",
                    parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdAgendaCliente ?? 0;
        }

        public void DeletarTudoAgendaCliente(int idCliente)
        {
            var contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@idCliente", idCliente)
            };

            contexto.Database.ExecuteSqlRaw("EXEC sp_AtualizarAgendaCliente @idCliente", parametros);
        }

        public List<AgendaCliente> ObterAgendaClientePorId(int id)
        {
            Context contexto = new Context();
            var parametro = new SqlParameter("@IdCliente", id);
            return contexto.AgendaCliente
                .FromSqlRaw("exec sp_ObterAgendaPorCliente @IdCliente", parametro)
                .AsEnumerable().ToList();
        }
    }
}
