using Autonomus.ContextNameSpace;
using Autonomus.Entities;
using Autonomus.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace Autonomus.Business
{
    public class PrestadorBO
    {

            public List<Prestador> ObterPrestador()
            {
                Context contexto = new Context();
                var resultado = contexto.Prestador.FromSqlRaw("exec sp_SelecionarPrestador");
                return resultado.ToList();

            }

            public Prestador? ObterPrestadorPorId(int id)
            {
                Context contexto = new Context();
                var parametro = new SqlParameter("@IdPrestador", id);
                return contexto.Prestador
                    .FromSqlRaw("exec sp_SelecionarPrestadorPorId @IdPrestador", parametro)
                    .AsEnumerable()
                    .FirstOrDefault();
            }

        public static decimal InserirPrestador(Prestador prestador)
            {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@NomePrestador", prestador.NomePrestador ?? (object)DBNull.Value),
                new SqlParameter("@SobrenomePrestador", prestador.SobrenomePrestador ?? (object)DBNull.Value),
                new SqlParameter("@TelefonePrestador", prestador.TelefonePrestador ?? (object)DBNull.Value),
                new SqlParameter("@EmailPrestador", prestador.EmailPrestador ?? (object)DBNull.Value),
                new SqlParameter("@GeneroPrestador", prestador.GeneroPrestador ?? (object)DBNull.Value),
                new SqlParameter("@EstadoPrestador", prestador.EstadoPrestador ?? (object)DBNull.Value),
                new SqlParameter("@AvaliacaoPrestador", prestador.AvaliacaoPrestador),
                new SqlParameter("@SenhaPrestador", Criptografia.Criptografar(prestador.SenhaPrestador) ?? (object)DBNull.Value)
             };

            var resultado = contexto
                .Set<NovoPrestadorResultado>()
                .FromSqlRaw("EXEC sp_InserirPrestador @NomePrestador, @SobrenomePrestador, @TelefonePrestador, @EmailPrestador, @GeneroPrestador, @EstadoPrestador, @AvaliacaoPrestador, @SenhaPrestador", parametros)
                .AsEnumerable()
                .FirstOrDefault();

            return resultado?.NovoIdPrestador ?? 0; 
        }

            public void DeletarPrestador(int idPrestador)
            {
                var contexto = new Context();
                var parametros = new[]
                {
                new SqlParameter("@IdPrestador", idPrestador)
            };

                contexto.Database.ExecuteSqlRaw("EXEC dboDeletarPrestador @IdPrestador", parametros);
            }

            public static void AtualizarPrestador(Prestador prestador)
            {
            using Context contexto = new Context();

            var parametros = new[]
            {
                new SqlParameter("@NomePrestador", prestador.NomePrestador ?? (object)DBNull.Value),
                new SqlParameter("@SobrenomePrestador", prestador.SobrenomePrestador ?? (object)DBNull.Value),
                new SqlParameter("@TelefonePrestador", prestador.TelefonePrestador ?? (object)DBNull.Value),
                new SqlParameter("@EmailPrestador", prestador.EmailPrestador ?? (object)DBNull.Value),
                new SqlParameter("@GeneroPrestador", prestador.GeneroPrestador ?? (object)DBNull.Value),
                new SqlParameter("@EstadoPrestador", prestador.EstadoPrestador ?? (object)DBNull.Value),
                new SqlParameter("@AvaliacaoPrestador", prestador.AvaliacaoPrestador),
                new SqlParameter("@SenhaPrestador", prestador.SenhaPrestador ?? (object)DBNull.Value),
                new SqlParameter("@idPrestador", prestador.IdPrestador)
             };

            contexto.Database.ExecuteSqlRaw(
                "EXEC sp_UpdatePrestador @NomePrestador, @SobrenomePrestador, @TelefonePrestador, @EmailPrestador, @GeneroPrestador, @EstadoPrestador, @AvaliacaoPrestador, @SenhaPrestador, @idPrestador",
                parametros
            );
        }

             public List<Prestador> ObterPrestadorPorRating(decimal avaliacaominima, decimal avaliacaomaxima)
             {
            Context contexto = new Context();
            var parametros = new[]
            {
            new SqlParameter("@MinAvaliacao", avaliacaominima),
            new SqlParameter("@MaxAvaliacao", avaliacaomaxima),
            };

            
            var resultado = contexto.Prestador.FromSqlRaw("exec sp_FiltrarPrestadorAvaliacao @MinAvaliacao, @MaxAvaliacao", parametros).ToList();

            return resultado;
        }

        public List<Prestador> FiltrarPrestadores(string? nomePrestador)
        {
            using var contexto = new Context();
            var parametro = new SqlParameter("@NomePrestador",
                               string.IsNullOrEmpty(nomePrestador) ? DBNull.Value : nomePrestador);

            var resultado = contexto.Prestador
                .FromSqlRaw("EXEC sp_FiltrarPrestadores @NomePrestador", parametro)
                .ToList();

            return resultado;
        }

        public List<Prestador> FiltrarPorEstado(string? estado)
        {
            using var contexto = new Context();
            var parametro = new SqlParameter("@EstadoPrestador",
                               string.IsNullOrEmpty(estado) ? DBNull.Value : estado);

            var resultado = contexto.Prestador
                .FromSqlRaw("EXEC sp_FiltrarPrestadorEstado @EstadoPrestador", parametro)
                .AsNoTracking()
                .ToList();

            return resultado;
        }
        
    }
}


