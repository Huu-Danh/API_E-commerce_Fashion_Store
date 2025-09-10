using E_commerce_fashion_store.Dtos.Gender;
using E_commerce_fashion_store.Models;

namespace E_commerce_fashion_store.Mappers
{
    public static class GenderMapper
    {
        public static GenderDto ToGenderDto(this Gender genderModel)
        {
            return new GenderDto
            {
                Id = genderModel.Id,
                Name = genderModel.Name,
                Description = genderModel.Description,
                Code = genderModel.Code,
                Products = genderModel.Products.Select(p => p.ToProductDto()).ToList(),
            };
        }

        public static Gender ToGenderFromCreateGenderDto(this CreateGenderDto genderDto)
        {
            return new Gender
            {
                Name = genderDto.Name,
                Description = genderDto.Description,
                Code = genderDto.Code,
            };
        }

    }
}
