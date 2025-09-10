using E_commerce_fashion_store.Dtos.Product;
using E_commerce_fashion_store.Extentions;
using E_commerce_fashion_store.Models;

namespace E_commerce_fashion_store.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                SKU = productModel.SKU,
                Slug = productModel.Slug,
                Description = productModel.Description,
                CategoryId = productModel.CategoryId,
                Brand = productModel.Brand,
                Price = (decimal)productModel.Price,
                Status = productModel.Status,
                ThumbnaiUrl = productModel.ThumbnaiUrl,
                CreatedAt = productModel.CreatedAt,
                UpdatedAt = productModel.UpdatedAt,
                GenderId = productModel.GenderId,
            };
        }

        public static Product ToProductFromProductDto(this CreateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                SKU = productDto.SKU,
                Slug = SlugExtention.GenerateSlug(productDto.Name),
                Description = productDto.Description,
                CategoryId = productDto.CategoryId,
                Brand = productDto.Brand,
                Price = (decimal)productDto.Price,
                ThumbnaiUrl = productDto.ThumbnaiUrl,
                GenderId = productDto.GenderId,
            };
        }
    }
}
