using E_commerce_fashion_store.Dtos.Categorie;
using E_commerce_fashion_store.Models;

namespace E_commerce_fashion_store.Mappers
{
    public static class CategorieMapper
    {
        public static CategorieDto ToCategorieDto(this Categorie CategorieModel)
        {
            return new CategorieDto
            {
                Id = CategorieModel.Id,
                Name = CategorieModel.Name,
                Description = CategorieModel.Description,
                CreatedAt = CategorieModel.CreatedAt,
                Products = CategorieModel.Products.Select(p => p.ToProductDto()).ToList(),
            };
        }

        public static Categorie ToCategorieFromCategorieDto(this CreateCategorieDto CategorieDto)
        {
            return new Categorie
            {
                Name = CategorieDto.Name,
                Description = CategorieDto.Description,
            };
        }
    }
}
