using Microsoft.AspNetCore.Mvc;
using post.microservice.Dto;
using post.microservice.services;
using User.Microservice.Rabbit;

namespace post.microservice.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRabbitMQ _rabbitMq;
        public UserController(IUserService userService, IRabbitMQ rabbitMq) { 
            _userService = userService;
            _rabbitMq = rabbitMq;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok();
        }

        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user= await _userService.GetById(id);
            if(user == null)
            {
                return BadRequest();
            }
            _rabbitMq.Send<UserDto>("usuario", user);
            
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDto userDto)
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto user)
        {

           
            var userDto=await _userService.Register(user);
            return Ok(userDto);
        }


       

    }
}
