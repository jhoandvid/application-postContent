using category.microservice.Data;
using category.microservice.Dtos;
using category.microservice.Model;
using Microsoft.EntityFrameworkCore;

namespace category.microservice.Repository
{
    public class CategoryRepository : ICategoryReposity
    {
        private readonly CategoryContext _context;

        public CategoryRepository(CategoryContext context)
        {
            _context = context;
        }
        public async Task CreateCategory(CategoryModel category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();

        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            return await _context.Categories.Where(c=>c.IsActive==true).ToListAsync();
        }

        public Task<List<CategoryModel>> GetCategoriesByIds(List<int> ids)
        {
           var categories= _context.Categories.Where(c=> ids.Contains(c.Id) && c.IsActive==true).ToListAsync();
            return categories;
        }

        public async Task<CategoryModel?> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && c.IsActive == true);
            return category;

        }
    }
}
