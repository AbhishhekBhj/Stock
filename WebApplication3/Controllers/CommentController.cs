using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDBContext applicationDBContext;
        private readonly ICommentRepostiory commentRepostitoy;

        public CommentController(ICommentRepostiory comment)
        {
            this.commentRepostitoy = comment;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllCommentAsync()
        {
            var comments = await commentRepostitoy.GetAllCommentsAsync();
            return Ok(comments);
        
        }
        

        [HttpGet ("{id}")]
        
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var comment = commentRepostitoy.GetCommentById(id);
            return Ok(comment);
        }

        //public IActionResult GetCommentByID([FromRoute ] int id)
        //{
        //    var comment = applicationDBContext.Comments.FirstOrDefault(e => e.CommentID == id);

        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(comment);


        //}




    }
}
