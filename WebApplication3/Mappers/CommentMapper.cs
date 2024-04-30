using WebApplication3.DTOs.Comments;
using WebApplication3.Models;

namespace WebApplication3.Mappers
{
    public static class CommentMapper
    {
        public static  CommentDTO ToCommentDTO(this Comment comment)
        {
            return new CommentDTO
            {
                CommentID = comment.CommentID,
                CommentContent = comment.CommentContent,
                CommentTitle = comment.CommentTitle,
                 CreatedOn = comment.CreatedOn,
                 StockID = comment.StockID

                


            };
        }
    }
}
