using Contract.API;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetShopWebAPI.Controllers
{
    //This controller is responsible to CRUD operations of the Comment entity.

    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        public CommentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var comments = unitOfWork.Comments.GetAll();
            return Ok(comments);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var comment = unitOfWork.Comments.Get(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }
        [HttpPost]
        public IActionResult PostComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Comments.Create(comment);
                unitOfWork.Complete();
                return Created("", comment);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Comments.Update(comment);
                unitOfWork.Complete();
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comment = unitOfWork.Comments.Get(id);
            if(comment == null) return NotFound();
            
            unitOfWork.Comments.Delete(comment);
            unitOfWork.Complete();
            return NoContent();
        }
    }
}
