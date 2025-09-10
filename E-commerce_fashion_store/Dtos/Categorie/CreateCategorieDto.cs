using System.ComponentModel.DataAnnotations;

namespace E_commerce_fashion_store.Dtos.Categorie
{
    public class CreateCategorieDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Tên danh mục không vượt quá 100 ký tự")]
        public string Name { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Mô tả danh mục không vượt quá 255 ký tự")]
        public string Description { get; set; }
    }
}
