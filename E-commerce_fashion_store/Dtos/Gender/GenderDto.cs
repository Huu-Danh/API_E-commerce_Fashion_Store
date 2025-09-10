using E_commerce_fashion_store.Dtos.Product;

namespace E_commerce_fashion_store.Dtos.Gender
{
    public class GenderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public List<ProductDto> Products { get; set; }
    }
}
