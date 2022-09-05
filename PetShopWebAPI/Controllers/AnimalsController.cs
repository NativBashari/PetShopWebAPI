using Contract.API;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetShopWebAPI.Controllers
{
    //This controller is responsible to CRUD operations of the Animal entity.

    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        public AnimalsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var animals = unitOfWork.Animals.GetAll();
            return Ok(animals);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var animal = unitOfWork.Animals.Get(id);
            if (animal == null) return NotFound();
            else
                return Ok(animal);
        }

        [HttpPost]
        public IActionResult PostAnimal(Animal animal)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Animals.Create(animal);
                unitOfWork.Complete();
                return Created("", animal);
            }
            else
                return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateAnimal(Animal animal)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Animals.Update(animal);
                unitOfWork.Complete();
                return NoContent();
            }
            else
                return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = unitOfWork.Animals.Get(id);
            if (animal == null) return NotFound();
            else
            {
                unitOfWork.Animals.Delete(animal);
                unitOfWork.Complete();
                return NoContent();
            }
        }

    }
}
