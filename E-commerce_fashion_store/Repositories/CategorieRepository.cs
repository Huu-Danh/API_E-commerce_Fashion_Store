using E_commerce_fashion_store.Data;
using E_commerce_fashion_store.Dtos.Categorie;
using E_commerce_fashion_store.Interfaces;
using E_commerce_fashion_store.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_fashion_store.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly ApplicationDBContext _context;

        public CategorieRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Categorie>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Categorie?> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(p => p.Products).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Categorie?> CreateCategorieAsync(Categorie categorieModel)
        {
            await _context.Categories.AddAsync(categorieModel);
            await _context.SaveChangesAsync();
            return categorieModel;
        }

        public async Task<Categorie?> UpdateCategorieAsync(int id, UpdateCategorieDto categorieModel)
        {
            var exitingCategorie = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (exitingCategorie == null) { return null; }
            exitingCategorie.Name = categorieModel.Name;
            exitingCategorie.Description = categorieModel.Description;
            await _context.SaveChangesAsync();
            return exitingCategorie;
        }

        public async Task<Categorie?> DeleteCategorieAsybc(int id)
        {
            var exitingCategorie = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (exitingCategorie == null) { return null; }
            _context.Categories.Remove(exitingCategorie);
            await _context.SaveChangesAsync();
            return exitingCategorie;
        }
    }
}
