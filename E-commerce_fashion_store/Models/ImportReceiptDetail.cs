using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("ImportReceiptDetails")]
    public class ImportReceiptDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ImportPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public int? ImportReceiptId { get; set; }
        public ImportReceipt? ImportReceipt { get; set; }

        public int? PoductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }
    }
}
