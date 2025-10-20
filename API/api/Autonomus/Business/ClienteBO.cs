using Autonomus.Entities;
using Microsoft.EntityFrameworkCore;
using Autonomus.ContextNameSpace;
using Microsoft.Data.SqlClient;
using static Autonomus.Business.ClienteBO;
using Autonomus.Helper;

namespace Autonomus.Business
{
    public class ClienteBO
    {
        public List<Cliente> ObterClientes()
        {
            Context contexto = new Context();
            var resultado = contexto.Cliente.FromSqlRaw("exec sp_SelecionarClientes").ToList();

            return resultado.ToList();
        }

        public Cliente? ObterClientePorId(int id)
        {
            Context contexto = new Context();
            var parametro = new SqlParameter("@IdCliente", id);
            return contexto.Cliente
                .FromSqlRaw("exec sp_SelecionarClientePorId @IdCliente", parametro)
                .AsEnumerable()
                .FirstOrDefault();
        }

        public decimal InserirCliente(Cliente cliente)
        {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@NomeCliente", cliente.NomeCliente ?? (object)DBNull.Value),
                new SqlParameter("@SobrenomeCliente", cliente.SobrenomeCliente ?? (object)DBNull.Value),
                new SqlParameter("@EmailCliente", cliente.EmailCliente ?? (object)DBNull.Value),
                new SqlParameter("@GeneroCliente", cliente.GeneroCliente ?? (object)DBNull.Value),
                new SqlParameter("@EstadoCliente", cliente.EstadoCliente ?? (object)DBNull.Value),
                new SqlParameter("@TelefoneCliente", cliente.TelefoneCliente ?? (object)DBNull.Value),
                new SqlParameter("@SenhaCliente", Criptografia.Criptografar(cliente.SenhaCliente) ?? (object)DBNull.Value),
                new SqlParameter("@AvaliacaoCliente", cliente.AvaliacaoCliente),
            };

            var resultado = contexto
                .Set<NovoClienteResultado>()
                .FromSqlRaw(
                    "EXEC sp_InserirCliente @NomeCliente, @SobrenomeCliente, @EmailCliente, @GeneroCliente, @EstadoCliente, @TelefoneCliente, @SenhaCliente, @AvaliacaoCliente",
                    parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdCliente ?? 0;
        }

        public void DeletarCliente(int idCliente)
        {
            var contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@IdCliente", idCliente)
            };

            contexto.Database.ExecuteSqlRaw("EXEC dboDeletarCliente @IdCliente", parametros);
        }

        public void AtualizarCliente(Cliente cliente)
        {
            using Context contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@idCliente", cliente.IdCliente),
                new SqlParameter("@NomeCliente", cliente.NomeCliente ?? (object)DBNull.Value),
                new SqlParameter("@SobrenomeCliente", cliente.SobrenomeCliente ?? (object)DBNull.Value),
                new SqlParameter("@EmailCliente", cliente.EmailCliente ?? (object)DBNull.Value),
                new SqlParameter("@GeneroCliente", cliente.GeneroCliente ?? (object)DBNull.Value),
                new SqlParameter("@EstadoCliente", cliente.EstadoCliente ?? (object)DBNull.Value),
                new SqlParameter("@TelefoneCliente", cliente.TelefoneCliente ?? (object)DBNull.Value),
                new SqlParameter("@SenhaCliente", cliente.SenhaCliente),
                new SqlParameter("@AvaliacaoCliente", cliente.AvaliacaoCliente)
            };

            contexto.Database.ExecuteSqlRaw(
                "EXEC sp_UpdateCliente  @idCliente, @NomeCliente, @SobrenomeCliente, @EmailCliente, @GeneroCliente, @EstadoCliente, @TelefoneCliente, @SenhaCliente, @AvaliacaoCliente",
                parametros
            );
        }

        public List<Cliente> ObterClientesPorRating(decimal avaliacaominima, decimal avaliacaomaxima)
        {
            Context contexto = new Context();
            var parametros = new[]
            {
                new SqlParameter("@MinAvaliacao", avaliacaominima),
                new SqlParameter("@MaxAvaliacao", avaliacaomaxima),
            };

            var resultado = contexto.Cliente.FromSqlRaw("exec sp_FiltrarClientesAvaliacao @MinAvaliacao, @MaxAvaliacao", parametros);
            return resultado.ToList();

        }

        public List<Cliente> FiltrarClientes(string? nomeCliente)
        {
            using var contexto = new Context();
            var parametro = new SqlParameter("@NomeCliente",
                               string.IsNullOrEmpty(nomeCliente) ? DBNull.Value : nomeCliente);

            var resultado = contexto.Cliente
                .FromSqlRaw("EXEC sp_FiltrarClientes @NomeCliente", parametro)
                .ToList();

            return resultado;
        }

        public List<Cliente> FiltrarPorEstado(string? estado)
        {
            using var contexto = new Context();
            var parametro = new SqlParameter("@EstadoCliente",
                               string.IsNullOrEmpty(estado) ? DBNull.Value : estado);

            var resultado = contexto.Cliente
                .FromSqlRaw("EXEC sp_FiltrarClienteEstado @EstadoCliente", parametro)
                .AsNoTracking()
                .ToList();

            return resultado;
        }








       
    }
}



