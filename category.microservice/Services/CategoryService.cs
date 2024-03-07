using AutoMapper;
using category.microservice.Dtos;
using category.microservice.Model;
using category.microservice.Repository;
using CategoryApi;
using Grpc.Core;

namespace category.microservice.Services
{
    public class CategoryService: CategoryGrpc.CategoryGrpcBase, ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryReposity _categoryRepository;
        public CategoryService(IMapper mapper,ICategoryReposity categoryRepository) {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategory(CreateCategoryDto category)
        {
            var categoryModel = _mapper.Map<CategoryModel>(category);
            await _categoryRepository.CreateCategory(categoryModel);
        }

      
        

        public async Task<List<CategoryDto>> GetAllCategories()
        {

            var categories = await _categoryRepository.GetAllCategories();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetCategoryById(int id)
        {
            var category= await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return null;
            }
            return _mapper.Map<CategoryDto>(category);
        }

        public override async Task<GetCategoryResponse> GetCategoriesByIds(GetCategoryRequest request, ServerCallContext context)
        {
            var ids=request.Id.ToList();
            var categories = await _categoryRepository.GetCategoriesByIds(ids);


            var response = new GetCategoryResponse();
            response.Category.AddRange(categories.Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name
            }));

            return response;

        }



    }
}
