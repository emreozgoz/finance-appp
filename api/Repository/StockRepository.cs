using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
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

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _applicationDbContext.Stocks.Include(x => x.Comments).AsQueryable();
            if (!string.IsNullOrEmpty(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrEmpty(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.isDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Stocks.Include(x => x.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<bool> StockExist(int id)
        {
            return await _applicationDbContext.Stocks.AnyAsync(x => x.Id == id);
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
