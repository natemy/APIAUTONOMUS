using Autonomus.Business;
using Autonomus.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Autonomus.Controllers
{

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]


    public class LoginController : ControllerBase
    {
        [HttpPost(Name = "Login")]
        public ActionResult<List<Login>> Post([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Senha))
                return BadRequest("Email e senha são obrigatórios.");

            LoginBO loginBO = new LoginBO();
            var resultado = loginBO.EfetuarLogin(request.Email, request.Senha);

            if (resultado == null || !resultado.Any())
                return NotFound("Login inválido.");

            return Ok(resultado);
        }
    }
}
