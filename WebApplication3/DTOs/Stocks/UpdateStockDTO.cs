namespace WebApplication3.DTOs.Stocks
{
    public class UpdateStockDTO
    {
        public string Symbol { get; set; } = string.Empty; //avoid null refernce


        public string CompanyName { get; set; } = string.Empty;


        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; } //long to handle big data

        public decimal PurchasePrice { get; set; }
    }
}
