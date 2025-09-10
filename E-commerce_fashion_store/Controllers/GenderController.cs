using E_commerce_fashion_store.Data;
using E_commerce_fashion_store.Dtos.Gender;
using E_commerce_fashion_store.Interfaces;
using E_commerce_fashion_store.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_fashion_store.Controllers
{
    [ApiController]
    [Route("api/gender")]
    public class GenderController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IGenderRepository _genderRepo;

        public GenderController(ApplicationDBContext context, IGenderRepository genderRepo)
        {
            _context = context;
            _genderRepo = genderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGender()
        {
            var genders = await _genderRepo.GetAllGenderAsync();
            var gedersDto = genders.Select(s => s.ToGenderDto()).ToList();
            return Ok(gedersDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetGenderById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var gender = await _genderRepo.GetGenderById(id);
            if (gender == null) return NotFound();
            return Ok(gender.ToGenderDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenderAsync([FromBody] CreateGenderDto genderDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var gender = genderDto.ToGenderFromCreateGenderDto();
            await _genderRepo.CreateGenderAsync(gender);
            return CreatedAtAction(nameof(GetGenderById), new { id = gender.Id }, gender);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpDateGenderAsync([FromRoute] int id, UpdateGenderDto updateGenderDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var genderModel = await _genderRepo.UpdateGenderAsync(id, updateGenderDto);
            if (genderModel == null) return NotFound();
            return Ok(genderModel.ToGenderDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteGenderAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var genderModel = await _genderRepo.DeleteGenderAsync(id);
            if (genderModel == null) return NotFound();
            return NoContent();
        }
    }
}
