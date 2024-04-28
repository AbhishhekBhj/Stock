using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication3.Data;
using WebApplication3.DTOs.Stocks;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class CreateStockRepository : IStockRepository
    {

        // dependency injection
        private readonly ApplicationDBContext _dbContext;
        public CreateStockRepository(ApplicationDBContext applicationDBContext)
        {

            _dbContext = applicationDBContext;

        }

        public async Task<Stock> CreateStockAsync(Stock stock)
        {
            await _dbContext.Stocks.AddAsync(stock);
            await _dbContext.SaveChangesAsync();

            return stock;

        }

        public async Task<Stock?> DeleteStockAsync(int id)
        {
            var stock = await _dbContext.Stocks.FirstOrDefaultAsync(e => e.StockId == id);

            if (stock == null)
            {
                return null;
            }

            _dbContext.Stocks.Remove(
                stock);
            await _dbContext
                      .SaveChangesAsync();

            return stock;



        }

        //implementing interface
        public async Task<List<Stock>> GetAllAsync()
        {

            return await _dbContext.Stocks.ToListAsync();



        }

        public async Task<Stock?> GetStockAsync(int id)
        {
            var stock = _dbContext.Stocks.FirstOrDefaultAsync(e => e.StockId == id);

            if (stock == null)
            {
                return null;
            }
            return await stock;


        }

        public async Task<Stock?> UpdateStockAsync(int id, UpdateStockDTO updateStockDTO)
        {
            var stock = await _dbContext.Stocks.FirstOrDefaultAsync(e => e.StockId == id);
            if (stock == null)
            {
                return null;
            }

            stock.PurchasePrice = updateStockDTO.PurchasePrice;
            stock.LastDiv = updateStockDTO.LastDiv;
            stock.MarketCap = updateStockDTO.MarketCap;
            stock.CompanyName = updateStockDTO.CompanyName;
            stock.Industry = updateStockDTO.Industry;
            stock.Symbol = updateStockDTO.Symbol;

            await _dbContext.SaveChangesAsync();

            return stock;
        }
    }
}
