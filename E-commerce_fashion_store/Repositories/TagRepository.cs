using E_commerce_fashion_store.Data;
using E_commerce_fashion_store.Dtos.Tag;
using E_commerce_fashion_store.Interfaces;
using E_commerce_fashion_store.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_fashion_store.Repositories
{
    public class TagRepository : ITagRepository
    {
        public readonly ApplicationDBContext _context;
        public TagRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Tag?> CreateTagAsync(Tag tagModel)
        {
            await _context.Tags.AddAsync(tagModel);
            await _context.SaveChangesAsync();
            return tagModel;

        }

        public async Task<Tag?> DeleteTagAsync(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if (tag == null) { return null; }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<List<Tag>> GetAllTagAsync()
        {
            var Tags = await _context.Tags.ToListAsync();
            return Tags;
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            return tag;
        }

        public async Task<Tag?> UpdateTagAsync(int id, UpdateTagDto tagDto)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if (tag == null) { return null; }
            tag.Name = tagDto.Name;
            tag.Description = tagDto.Description;
            tag.Slug = tagDto.Slug;
            tag.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return tag;
        }
    }
}
