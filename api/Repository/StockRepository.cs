using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StockRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _applicationDbContext.Stocks.AddAsync(stockModel);
            await _applicationDbContext.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var result = await _applicationDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            _applicationDbContext.Remove(result);
            await _applicationDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _applicationDbContext.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Stocks.FindAsync(id);
        }

        public async Task<Stock?> UpdateAsync(UpdateStockRequest stockRequestModel, int id)
        {
            var result = await _applicationDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            result.Purchase = stockRequestModel.Purchase;
            result.Symbol = stockRequestModel.Symbol;
            result.MarketCap = stockRequestModel.MarketCap;
            result.CompanyName = stockRequestModel.CompanyName;
            result.LastDiv = stockRequestModel.LastDiv;
            result.Industry = stockRequestModel.Industry;
            await _applicationDbContext.SaveChangesAsync();
            return result;
        }
    }
}
