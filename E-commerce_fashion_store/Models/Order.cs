using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string ShippingName { get; set; } = string.Empty;
        public string ShippingPhone { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingFee { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public List<OrderDiscount> OrderDiscounts { get; set; } = new List<OrderDiscount>();
    }
}
