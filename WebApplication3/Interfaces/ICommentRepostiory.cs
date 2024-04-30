using WebApplication3.DTOs.Comments;
using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface ICommentRepostiory
    {
        public  Task<List<Comment>> GetAllCommentsAsync();

        public Task<Comment?> GetCommentByIdAsync(int id);
    }
}
