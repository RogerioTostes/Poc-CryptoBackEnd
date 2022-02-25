using Game.Services.Models;
using Game.Services.Repository;
using Game.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Token : ControllerBase
    {
        private readonly ILogger<Token> _logger;

        public Token(ILogger<Token> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost (Name = "Login")]
        public IActionResult Auth([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username);

            if (user == null)
                return BadRequest(new
                {
                    Message = "Invalid authentication"
                });

            var token = TokenService.GenerateToken(user);

            return Ok(new
            {
                Token = token,
                User = user
            });
        }

        [Authorize]
        [HttpGet (Name = "Test")]
        public IActionResult TestAuth()
        {
            var teste = User;
            return Ok(new
            {
                Message = "Sucesso: você está autenticado!"
            });
        }
    }
}