using Autonomus.Entities;
using Microsoft.EntityFrameworkCore;
using Autonomus.ContextNameSpace;
using Microsoft.Data.SqlClient;
using static Autonomus.Business.LoginBO;
using Autonomus.Helper;

namespace Autonomus.Business
{
    public class LoginBO
    {
        public List<Login> EfetuarLogin(string email, string senha)
        {
            Context contexto = new Context();
            SqlParameter pemail = new SqlParameter("@Email", email);
            SqlParameter psenha = new SqlParameter("@Senha", Criptografia.Criptografar(senha));
            object[] parametros = new object[3];
            parametros[0] = pemail;
            parametros[1] = psenha;
            var resultado = contexto.Login.FromSqlRaw("exec sp_Login @Email, @Senha", parametros).ToList();

            return resultado.ToList();

        }

     
        
    }
}
    



