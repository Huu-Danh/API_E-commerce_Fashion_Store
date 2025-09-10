using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("ImportReceipt")]
    public class ImportReceipt
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime ImportDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public string Note { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public AppUser AppUser { get; set; }
    }
}
