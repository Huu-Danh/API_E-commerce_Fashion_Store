using E_commerce_fashion_store.Dtos.Product;

namespace E_commerce_fashion_store.Dtos.Categorie
{
    public class CategorieDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
