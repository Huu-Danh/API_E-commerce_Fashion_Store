using E_commerce_fashion_store.Data;
using E_commerce_fashion_store.Dtos.Gender;
using E_commerce_fashion_store.Interfaces;
using E_commerce_fashion_store.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_fashion_store.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly ApplicationDBContext _context;
        public GenderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Gender?> CreateGenderAsync(Gender genderModel)
        {
            await _context.Genders.AddAsync(genderModel);
            await _context.SaveChangesAsync();
            return genderModel;
        }

        public async Task<List<Gender>> GetAllGenderAsync()
        {
            var genders = await _context.Genders.ToListAsync();
            return genders;
        }

        public async Task<Gender?> GetGenderById(int id)
        {
            return await _context.Genders.Include(p => p.Products).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Gender?> UpdateGenderAsync(int id, UpdateGenderDto genderDto)
        {
            var gender = await _context.Genders.FirstOrDefaultAsync(i => i.Id == id);
            if (gender == null) { return null; }
            gender.Name = genderDto.Name;
            gender.Description = genderDto.Description;
            gender.Code = genderDto.Code;
            await _context.SaveChangesAsync();
            return gender;
        }

        public async Task<Gender?> DeleteGenderAsync(int id)
        {
            var gender = await _context.Genders.FirstOrDefaultAsync(i => i.Id == id);
            if (gender == null) { return null; }
            _context.Genders.Remove(gender);
            await _context.SaveChangesAsync();
            return gender;
        }
    }
}
