using Game.Services.Interface;
using Game.Services.Models;
using Game.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IUsersRepository usersRepository;
        private readonly ILogger<Auth> _logger;

        public Auth(IUsersRepository usersRepository, ILogger<Auth> logger)
        {
            _logger = logger;
            this.usersRepository = usersRepository;
        }

        [HttpGet(Name = "Valida")]
        public async Task<IActionResult> Valida([FromQuery] string signature, [FromQuery] string publicAddress, [FromQuery] string nounce)
        {
            //var usuario = await usersRepository.Get(publicAddress);

            //var retorno = AutheticationService.ValidaAssinatura(usuario, signature);
            var retorno = AutheticationService.ValidaAssinatura(nounce, signature, publicAddress);

            if (retorno)
            {
                //await usersRepository.Insert(usuario);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
