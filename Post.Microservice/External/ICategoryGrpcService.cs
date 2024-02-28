using Post.Microservice.Dtos;
using Post.Microservice.Dtos.externalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.External
{
    public interface ICategoryGrpcService
    {
        public Task<List<CategoryDto>> GetAllCategoriesByIds(PostDto post);
        public ApiResponse<object> ValidCategoriesByIds(List<CategoryDto> categoriesDb, List<int> categoriesIds);

      
    }
}
