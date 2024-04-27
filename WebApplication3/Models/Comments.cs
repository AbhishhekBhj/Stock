namespace WebApplication3.Models
{
    public class Comment
    {

        public int? StockID { get; set; } // navigation property

        public Stock? Stock { get; set; }

        public int CommentID { get; set; }

        public string CommentTitle { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now; // on object creation

        public string CommentContent { get; set; } = string.Empty;



    }
}
