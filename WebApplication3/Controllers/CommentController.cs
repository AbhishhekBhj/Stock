using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Mappers;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepostiory commentRepostitoy;

        public CommentController(ICommentRepostiory comment)
        {
            this.commentRepostitoy = comment;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllCommentAsync()
        {
            var comments = await commentRepostitoy.GetAllCommentsAsync();
            var commentDTO = comments.Select(e=>e.ToCommentDTO());
            
            return Ok(commentDTO);
        
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var comment =  await commentRepostitoy.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            
            return Ok(comment.ToCommentDTO());
        }

        




    }
}
