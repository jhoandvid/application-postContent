using CategoryApi;
using Post.Microservice.Dtos;
using Post.Microservice.Dtos.externalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.External.ServicesGrpc
{
    public  class CategoryGrpcService: ICategoryGrpcService
    {
        private readonly CategoryGrpc.CategoryGrpcClient _categoryGrpcClient;

        public CategoryGrpcService(CategoryGrpc.CategoryGrpcClient categoryGrpcClient)
        {
            _categoryGrpcClient = categoryGrpcClient;

        }

      

        public async Task<List<CategoryDto>> GetAllCategoriesByIds(PostDto post)
        {
            var request = new GetCategoryRequest();
            var categoriesIds = post.Categories.Select(s => s.IdCategory).ToList();
            request.Id.AddRange(categoriesIds);

            var results = await _categoryGrpcClient.GetCategoriesByIdsAsync(request);
            request.Id.Clear();

            var categoriesDto = results.Category.Select(c => new CategoryDto { IdCategory = c.Id, Name = c.Name }).ToList();
            return categoriesDto;

        }

        public ApiResponse<object> ValidCategoriesByIds(List<CategoryDto> categoriesDb, List<int> categoriesIds)
        {
            var idsNotFound = categoriesIds.Except(categoriesDb.Select(c => c.IdCategory));

            if (idsNotFound.Any())
            {
                return new ApiResponse<object>() { Issuccess = false, Messague = "Error al guardar las categorias, las categorias con los siguientes ids no existen", Result =  idsNotFound };
            }

            return new ApiResponse<object>() { Issuccess = true, Result=null};
        }
    }
}
