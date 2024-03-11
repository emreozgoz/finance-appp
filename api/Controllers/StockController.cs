using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StockController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _applicationDbContext.Stocks.ToList().Select(x => x.ToStockDto());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _applicationDbContext.Stocks.Find(id);
            if (result == null)
                return NotFound();
            return Ok(result.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequest requestDto)
        {
            var result = requestDto.ToStockFromCreateDto();
            _applicationDbContext.Stocks.Add(result);
            _applicationDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequest requestDto)
        {
            var result = _applicationDbContext.Stocks.FirstOrDefault(x => x.Id == id);
            if (result == null)
                return NotFound();

            result.Purchase = requestDto.Purchase;
            result.Symbol = requestDto.Symbol;
            result.MarketCap = requestDto.MarketCap;
            result.CompanyName = requestDto.CompanyName;
            result.LastDiv = requestDto.LastDiv;
            result.Industry = requestDto.Industry;
            _applicationDbContext.SaveChanges();
            return Ok(result.ToStockDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _applicationDbContext.Stocks.FirstOrDefault(x => x.Id == id);
            if (result == null)
                return NotFound();

            _applicationDbContext.Stocks.Remove(result);
            _applicationDbContext.SaveChanges();
            return NoContent();
        }
    }
}
