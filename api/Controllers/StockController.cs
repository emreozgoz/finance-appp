using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] QueryObject query )
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _stockRepository.GetAllAsync(query);
            var stockDto = result.Select(x => x.ToStockDto()).ToList();
            return Ok(stockDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _stockRepository.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequest requestDto)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = requestDto.ToStockFromCreateDto();
            await _stockRepository.CreateAsync(result);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToStockDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequest requestDto)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _stockRepository.UpdateAsync(requestDto, id);
            if (result == null)
                return NotFound();
            return Ok(result.ToStockDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _stockRepository.DeleteAsync(id);
            if (result == null)
                return NotFound();

            return NoContent();
        }
    }
}
