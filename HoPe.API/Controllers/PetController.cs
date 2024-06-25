using HoPe.Application.InputModels;
using HoPe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HoPe.API.Controllers
{
    [Route("api/pet")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("id'")]
        public IActionResult GetById(int id)
        {
            var pet = _petService.GetById(id);
            return Ok(pet);
        }

        [HttpGet("query")]
        public IActionResult Get(string query)
        {
            var pets = _petService.Get(query);
            return Ok(pets);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatePetInputModel createPetInputModel)
        {
            var id = _petService.Post(createPetInputModel);
            return CreatedAtAction(nameof(GetById), new { id }, createPetInputModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdatePetInputModel updatePetInputModel)
        {
            _petService.Update(updatePetInputModel);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _petService.Delete(id);
            return NoContent();
        }
    }
}
