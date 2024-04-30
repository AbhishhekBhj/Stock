using WebApplication3.Models;

namespace WebApplication3.DTOs.Comments
{

    //data transfer object model class
    public class CommentDTO
    {

        public int? StockID { get; set; }

        

        public int CommentID { get; set; }

        public string CommentTitle { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now; // on object creation

        public string CommentContent { get; set; } = string.Empty;

    }
}
