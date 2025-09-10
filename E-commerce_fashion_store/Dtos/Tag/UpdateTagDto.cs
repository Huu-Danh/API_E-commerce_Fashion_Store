using System.ComponentModel.DataAnnotations;

namespace E_commerce_fashion_store.Dtos.Tag
{
    public class UpdateTagDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; } = string.Empty;

    }
}
