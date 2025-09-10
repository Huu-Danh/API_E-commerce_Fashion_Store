using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("ProductVariants")]
    public class ProductVariant
    {
        public int Id { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string VariantSKU { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
