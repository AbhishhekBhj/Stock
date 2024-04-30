using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.DTOs.Comments;
using WebApplication3.Models;


//this dto class will be used to handle the data received from the backend 
namespace WebApplication3.DTOs.Stocks
{
    public class StockDTO
    {
        public int StockId { get; set; }

        public string Symbol { get; set; } = string.Empty; //avoid null refernce


        public string CompanyName { get; set; } = string.Empty;


        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; } //long to handle big data

        public decimal PurchasePrice { get; set; }

        public List<CommentDTO> Comments { get; set; }
    }
}
