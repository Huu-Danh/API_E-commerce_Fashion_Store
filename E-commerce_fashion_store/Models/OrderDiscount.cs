using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("OrderDiscounts")]
    public class OrderDiscount
    {
        [Column(TypeName = "deciaml(18,2)")]
        public decimal AppliedValue { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public int? DiscountCodeId { get; set; }
        public DiscountCode? DiscountCode { get; set; }

    }
}
