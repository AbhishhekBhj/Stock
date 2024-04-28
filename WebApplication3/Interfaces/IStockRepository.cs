using WebApplication3.DTOs.Stocks;
using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetStockAsync(int id);

        Task<Stock> CreateStockAsync(Stock stock);

        Task<Stock> UpdateStockAsync(int id, UpdateStockDTO updateStockDTO);

        Task<Stock> DeleteStockAsync(int id);
    }
}
