namespace WebApplication3.DTOs.Stocks
{

    //this dto will be used to restrict the data fields posted by the user
    public class PostStockDTO
    {
        //user should not be able to post id and commments

        public string Symbol { get; set; } = string.Empty; //avoid null refernce


        public string CompanyName { get; set; } = string.Empty;


        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; } //long to handle big data

        public decimal PurchasePrice { get; set; }
    }
}
