using category.microservice.Dtos;
using category.microservice.Model;

namespace category.microservice.Repository
{
    public interface ICategoryReposity
    {
        public Task<List<CategoryModel>> GetAllCategories();

        public Task<CategoryModel?> GetCategoryById(int id);

        public Task CreateCategory(CategoryModel category);

        public Task<List<CategoryModel>> GetCategoriesByIds(List<int> ids);

    }
}
