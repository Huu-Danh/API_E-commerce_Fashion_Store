using System.ComponentModel.DataAnnotations;

namespace E_commerce_fashion_store.Dtos.Gender
{
    public class UpdateGenderDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string Code { get; set; } = string.Empty;
    }
}
