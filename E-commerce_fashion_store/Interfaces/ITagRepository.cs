using E_commerce_fashion_store.Dtos.Tag;
using E_commerce_fashion_store.Models;

namespace E_commerce_fashion_store.Interfaces
{
    public interface ITagRepository
    {
        public Task<List<Tag>> GetAllTagAsync();
        public Task<Tag?> GetByIdAsync(int id);
        public Task<Tag?> CreateTagAsync(Tag tagModel);
        public Task<Tag?> UpdateTagAsync(int id, UpdateTagDto tagDto);
        public Task<Tag?> DeleteTagAsync(int id);
    }
}
