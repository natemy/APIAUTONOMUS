using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Autonomus.Business
{
    public class HorariosCompativeisBO
    {
        public List<AgendaPrestador> ObterHorariosCompativeis(int idPrestador, int idCliente)
        {
            Context contexto = new Context();
            var parametroPrestador = new SqlParameter("@PrestadorID", idPrestador);
            var parametroCliente = new SqlParameter("@ClienteID", idCliente);
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = parametroPrestador;
            parametros[1] = parametroCliente;
            return contexto.AgendaPrestador
                .FromSqlRaw("exec SP_BuscarHorariosCompativeis @ClienteID, @PrestadorID", parametros)
                .AsEnumerable().ToList();

        }
    }
}
