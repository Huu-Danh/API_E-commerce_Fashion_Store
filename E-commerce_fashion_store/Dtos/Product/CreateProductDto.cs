using System.ComponentModel.DataAnnotations;

namespace E_commerce_fashion_store.Dtos.Product
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 ký tự.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "SKU là bắt buộc.")]
        [StringLength(50, ErrorMessage = "SKU không được vượt quá 50 ký tự.")]
        public string SKU { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 ký tự.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Thương hiệu là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Thương hiệu không được vượt quá 100 ký tự.")]
        public string Brand { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Ảnh đại diện là bắt buộc.")]
        [Url(ErrorMessage = "Ảnh đại diện phải là một URL hợp lệ.")]
        public string ThumbnaiUrl { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "GenderId không hợp lệ.")]
        public int GenderId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CategoryId không hợp lệ.")]
        public int CategoryId { get; set; }
    }
}
