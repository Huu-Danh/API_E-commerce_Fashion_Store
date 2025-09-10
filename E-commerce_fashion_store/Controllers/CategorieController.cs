using E_commerce_fashion_store.Data;
using E_commerce_fashion_store.Dtos.Categorie;
using E_commerce_fashion_store.Interfaces;
using E_commerce_fashion_store.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_fashion_store.Controllers
{
    [ApiController]
    [Route("api/categorie")]
    public class CategorieController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly ICategorieRepository _categorieRepo;

        public CategorieController(ApplicationDBContext context, ICategorieRepository categorieRepo)
        {
            _context = context;
            _categorieRepo = categorieRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorie()
        {
            var categories = await _categorieRepo.GetAllAsync();
            var categorieDto = categories.Select(s => s.ToCategorieDto()).ToList();
            return Ok(categorieDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdCategorie([FromRoute] int id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var categoie = await _categorieRepo.GetByIdAsync(id);
            if (categoie == null) { return NotFound(); }
            return Ok(categoie.ToCategorieDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategorie([FromBody] CreateCategorieDto categorieDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var categorieModel = categorieDto.ToCategorieFromCategorieDto();
            await _categorieRepo.CreateCategorieAsync(categorieModel);
            return CreatedAtAction(nameof(GetByIdCategorie), new { id = categorieModel.Id }, categorieModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCategorie([FromRoute] int id, UpdateCategorieDto updateCategorieDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var categorieModel = await _categorieRepo.UpdateCategorieAsync(id, updateCategorieDto);
            if (categorieModel == null) { return NotFound(); }
            return Ok(categorieModel.ToCategorieDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCategorie([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var categorieModel = await _categorieRepo.DeleteCategorieAsybc(id);
            if (categorieModel == null) return NotFound();
            return NoContent();
        }
    }
}
