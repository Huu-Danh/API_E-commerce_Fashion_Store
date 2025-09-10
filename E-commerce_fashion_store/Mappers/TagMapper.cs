using E_commerce_fashion_store.Dtos.Tag;
using E_commerce_fashion_store.Models;

namespace E_commerce_fashion_store.Mappers
{
    public static class TagMapper
    {
        public static TagDto ToTagDto(this Tag tagModel)
        {
            return new TagDto
            {
                Id = tagModel.Id,
                Name = tagModel.Name,
                Description = tagModel.Description,
                Slug = tagModel.Slug,
                CreatedAt = tagModel.CreatedAt,
                UpdatedAt = tagModel.UpdatedAt,
            };
        }

        public static Tag ToTagFromCreateTagDto(this CreateTagDto tagDto)
        {
            return new Tag
            {
                Name = tagDto.Name,
                Description = tagDto.Description,
                Slug = tagDto.Slug,
            };
        }


    }
}
