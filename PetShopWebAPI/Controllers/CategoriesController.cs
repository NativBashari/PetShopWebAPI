using Contract.API;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetShopWebAPI.Controllers
{
    //This controller is responsible to CRUD operations of the Category entity.

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var categories = unitOfWork.Categories.GetAll();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = unitOfWork.Categories.Get(id);
            if (category == null) return NotFound();
            else
                return Ok(category);
        }
        [HttpPost]
        public IActionResult PostCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Categories.Create(category);
                unitOfWork.Complete();
                return Created("",category);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Categories.Update(category);
                unitOfWork.Complete();
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = unitOfWork.Categories.Get(id);
            if (category == null) return NotFound();

            unitOfWork.Categories.Delete(category);
            unitOfWork.Complete();
            return NoContent();
        }
    }
}
