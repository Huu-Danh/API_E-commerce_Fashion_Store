using E_commerce_fashion_store.Data;
using E_commerce_fashion_store.Dtos.Product;
using E_commerce_fashion_store.Helpers;
using E_commerce_fashion_store.Interfaces;
using E_commerce_fashion_store.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_fashion_store.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductRepository _productRepo;

        public ProductController(ApplicationDBContext context, IProductRepository productRepo)
        {
            _context = context;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] ProductQueryObject queryObject)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var products = await _productRepo.GetAllAsync(queryObject);
            return Ok(products.Select(p => p.ToProductDto()));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var product = await _productRepo.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product.ToProductDto());
        }

        [HttpGet]
        [Route("{slug}")]
        public async Task<IActionResult> GetProductBySlug([FromRoute] string slug)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var product = await _productRepo.GetBySlugAsync(slug);
            return product == null ? NotFound() : Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var productModel = productDto.ToProductFromProductDto();
            await _productRepo.CreateProductAsync(productModel);
            return CreatedAtAction(nameof(GetProductById), new { id = productModel.Id }, productModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, UpdateProductDto productDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var productModel = await _productRepo.UpdateProductAsync(id, productDto);
            return productModel == null ? NotFound() : Ok(productModel.ToProductDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var product = await _productRepo.DeleteProductAsync(id);
            return product == null ? NotFound() : NoContent();
        }

    }
}
