using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class CommentRepostitoy:ICommentRepostiory
    {

        private readonly ApplicationDBContext applicationDBContext;

        public CommentRepostitoy(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public async Task<List<Comment>> GetAllCommentsAsync()
        {


            return  await applicationDBContext.Comments.ToListAsync();


        }

        public async Task<Comment?> GetCommentById(int id)
        {
            var comment = await applicationDBContext.Comments.SingleOrDefaultAsync(e => e.CommentID == id);
            if (comment == null)
            {
                return null;
            }

            return comment;
        }

    }
}
