using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        public int Id { get; set; }
        public int Quatity { get; set; }
        public DateTime LastUpdate { get; set; }
        public int? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }
    }
}
