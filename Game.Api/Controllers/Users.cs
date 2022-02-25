using Game.Services.Interface;
using Game.Services.Models;
using Game.Services.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase 
    { 

        private readonly IUsersRepository usersRepository;    
        private readonly ILogger<Users> _logger;

        public Users(IUsersRepository usersRepository, ILogger<Users> logger)
        {
            _logger = logger;
            this.usersRepository= usersRepository;
        }
       
        [HttpGet(Name = "Find")]        
        public async Task<IActionResult> Find([FromRoute] string publicAddress)
        {
            var retorno = await usersRepository.Get(publicAddress);
            return Ok(retorno);
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await usersRepository.Insert(user);
            return Ok();
        }

    }
}
