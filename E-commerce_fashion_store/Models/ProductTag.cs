using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("ProductTag")]
    public class ProductTag
    {
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public Product? Product { get; set; }
        public Tag? Tag { get; set; }
    }
}
