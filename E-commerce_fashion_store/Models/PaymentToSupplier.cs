using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("PaymentToSuppliers")]
    public class PaymentToSupplier
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Method { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public int? SupplierId { get; set; }
        public AppUser? AppUser { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
