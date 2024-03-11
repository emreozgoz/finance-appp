using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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
    }
}
