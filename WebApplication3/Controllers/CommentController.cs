using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDBContext applicationDBContext;

        public CommentController(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var comments = applicationDBContext.Comments.ToList(); //retriver all the comment objects

            return Ok(comments);

        }

        [HttpGet ("{id}")]

        public IActionResult GetCommentByID([FromRoute ] int id)
        {
            var comment = applicationDBContext.Comments.FirstOrDefault(e => e.CommentID == id);

            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);


        }




    }
}
