using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public string Note { get; set; } = string.Empty;

        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public int? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }
    }
}
