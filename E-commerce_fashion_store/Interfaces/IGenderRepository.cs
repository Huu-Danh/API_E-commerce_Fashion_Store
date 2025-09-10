using E_commerce_fashion_store.Dtos.Gender;
using E_commerce_fashion_store.Models;

namespace E_commerce_fashion_store.Interfaces
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetAllGenderAsync();
        Task<Gender?> GetGenderById(int id);
        Task<Gender?> CreateGenderAsync(Gender genderModel);
        Task<Gender?> UpdateGenderAsync(int id, UpdateGenderDto genderDto);
        Task<Gender?> DeleteGenderAsync(int id);
    }
}
