using HoPe.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoPe.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1}, createUserModel);
        }

        [HttpPut("id")]
        public IActionResult Login(int id, [FromBody] LoginModel loginModel)
        {
            return NoContent();
        }

        //terminei a parte de camada core parte 2
    }
}
