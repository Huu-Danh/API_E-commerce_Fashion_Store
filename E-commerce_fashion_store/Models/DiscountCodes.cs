using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("DiscountCodes")]
    public class DiscountCode
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DiscountType { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinDiscountAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxDiscountAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinOrderAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public bool IsPublic { get; set; }

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public List<OrderDiscount> OrderDiscounts { get; set; } = new List<OrderDiscount>();

    }
}
