using E_commerce_fashion_store.Data;
using E_commerce_fashion_store.Dtos.Product;
using E_commerce_fashion_store.Helpers;
using E_commerce_fashion_store.Interfaces;
using E_commerce_fashion_store.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_fashion_store.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync(ProductQueryObject queryObject)
        {
            var products = await _context.Products.ToListAsync();
            if (!string.IsNullOrWhiteSpace(queryObject.Name))
            {
                products = products.Where(p => p.Name.Contains(queryObject.Name)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if (queryObject.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    products = queryObject.IsDecsending ? products.OrderByDescending(p => p.Price).ToList() : products.OrderBy(p => p.Price).ToList();
                }
            }
            return products;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<Product?> GetBySlugAsync(string slug)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Slug == slug);
            return product;
        }

        public async Task<Product?> CreateProductAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> UpdateProductAsync(int id, UpdateProductDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) { return null; }
            product.Name = productDto.Name;
            product.SKU = productDto.SKU;
            product.Slug = productDto.Slug;
            product.Description = productDto.Description;
            product.Brand = productDto.Brand;
            product.Price = productDto.Price;
            product.Status = productDto.Status;
            product.ThumbnaiUrl = productDto.ThumbnaiUrl;
            product.CategoryId = productDto.CategoryId;
            product.GenderId = productDto.GenderId;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) { return null; }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> SlugExistsAsync(string slug)
        {
            return await _context.Products.AnyAsync(p => p.Slug == slug);
        }
    }
}
