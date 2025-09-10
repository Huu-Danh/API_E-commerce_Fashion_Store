using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_fashion_store.Models
{
    [Table("Genders")]
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
