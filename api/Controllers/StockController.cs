using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _stockRepository.GetAllAsync();
            var stockDto = result.Select(x => x.ToStockDto());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _stockRepository.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequest requestDto)
        {
            var result = requestDto.ToStockFromCreateDto();
            await _stockRepository.CreateAsync(result);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequest requestDto)
        {
            var result = await _stockRepository.UpdateAsync(requestDto, id);
            if (result == null)
                return NotFound();
            return Ok(result.ToStockDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _stockRepository.DeleteAsync(id);
            if (result == null)
                return NotFound();

            return NoContent();
        }
    }
}
