using category.microservice.Dtos;
using category.microservice.Model;
using CategoryApi;
using Grpc.Core;

namespace category.microservice.Services
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAllCategories();

        public Task<CategoryDto?> GetCategoryById(int id);

        public Task CreateCategory(CreateCategoryDto category);
        
    }
}
