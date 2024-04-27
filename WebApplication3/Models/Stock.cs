using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Stock
    {

        public int StockId { get; set; }

        public string Symbol { get; set; } = string.Empty; //avoid null refernce


        public string CompanyName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")] //define type

        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; } //long to handle big data


        //handle many coments
        public List<Comment> Comments { get; set; } = new List<Comment>();  // comment for the stock 


        [Column(TypeName = "decimal(18,2)")] //define type
        public decimal PurchasePrice { get; set; }

    }
}
