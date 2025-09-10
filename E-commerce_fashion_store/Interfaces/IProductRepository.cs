using E_commerce_fashion_store.Dtos.Product;
using E_commerce_fashion_store.Helpers;
using E_commerce_fashion_store.Models;

namespace E_commerce_fashion_store.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync(ProductQueryObject queryObject);
        public Task<Product?> GetByIdAsync(int id);
        public Task<Product?> GetBySlugAsync(string slug);
        public Task<Product?> CreateProductAsync(Product productModel);
        public Task<Product?> UpdateProductAsync(int id, UpdateProductDto productDto);
        public Task<Product?> DeleteProductAsync(int id);
        public Task<bool> SlugExistsAsync(string slug);
    }
}
