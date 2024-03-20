using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _commentRepository.GetAllAsync();
            var commentDto = result.Select(x => x.toCommentDto());
            return Ok(commentDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _commentRepository.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result.toCommentDto());
        }
        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto createCommentDto)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!await _stockRepository.StockExist(stockId))
            {
                return BadRequest("Stock is not exist");
            }
            var commentModel = createCommentDto.ToCommentFromCreateDto(stockId);
            await _commentRepository.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.toCommentDto());
        }

        [HttpDelete("{stockId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int stockId)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _commentRepository.DeleteAsync(stockId);
            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comment = await _commentRepository.UpdateAsync(id, updateDto.ToCommentFromUpdate(id));

            if (comment == null)
            {
                return NotFound("Comment not found");
            }

            return Ok(comment.toCommentDto());
        }
    }
}
