using HoPe.API.Models;
using HoPe.Application.InputModels;
using HoPe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HoPe.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel createUserModel)
        {
            var id = _userService.Post(createUserModel);
            return CreatedAtAction(nameof(GetById), new { id }, createUserModel);
        }

        [HttpPut("id")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            return NoContent();
        }

        //terminei a parte de camada core parte 2
    }
}
