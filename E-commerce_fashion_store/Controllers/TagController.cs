using E_commerce_fashion_store.Data;
using E_commerce_fashion_store.Dtos.Tag;
using E_commerce_fashion_store.Interfaces;
using E_commerce_fashion_store.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_fashion_store.Controllers
{
    [ApiController]
    [Route("api/tag")]
    public class TagController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly ITagRepository _tagRepo;
        public TagController(ApplicationDBContext context, ITagRepository tagRepo)
        {
            _context = context;
            _tagRepo = tagRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTag()
        {
            var tags = await _tagRepo.GetAllTagAsync();
            return Ok(tags.Select(t => t.ToTagDto()));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTagById([FromRoute] int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var tag = await _tagRepo.GetByIdAsync(id);
            return tag == null ? NotFound() : Ok(tag.ToTagDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagDto TagDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var tagModel = TagDto.ToTagFromCreateTagDto();
            await _tagRepo.CreateTagAsync(tagModel);
            return CreatedAtAction(nameof(GetTagById), new { id = tagModel.Id }, tagModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTag([FromRoute] int id, UpdateTagDto updateTagDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var tagModel = await _tagRepo.UpdateTagAsync(id, updateTagDto);
            return tagModel == null ? NotFound() : Ok(tagModel.ToTagDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var tagModel = await _tagRepo.DeleteTagAsync(id);
            return tagModel == null ? NotFound() : NoContent();
        }
    }
}
