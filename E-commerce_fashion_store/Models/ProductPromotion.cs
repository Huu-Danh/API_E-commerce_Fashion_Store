using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("ProductPromotion")]
    public class ProductPromotion
    {
        public int Id { get; set; }
        public string DiscountType { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; } = string.Empty;
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
