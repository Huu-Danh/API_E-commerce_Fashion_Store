using E_commerce_fashion_store.Dtos.Categorie;
using E_commerce_fashion_store.Models;

namespace E_commerce_fashion_store.Interfaces
{
    public interface ICategorieRepository
    {
        public Task<List<Categorie>> GetAllAsync();
        public Task<Categorie?> GetByIdAsync(int id);
        public Task<Categorie?> CreateCategorieAsync(Categorie categorieModel);
        public Task<Categorie?> UpdateCategorieAsync(int id, UpdateCategorieDto categorieModel);
        public Task<Categorie?> DeleteCategorieAsybc(int id);
    }
}
