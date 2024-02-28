using AutoMapper;
using category.microservice.Dtos;
using category.microservice.Model;
using CategoryApi;

namespace category.microservice.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<CategoryDto, CategoryModel>().ReverseMap();
            CreateMap<CreateCategoryDto, CategoryModel>();


        }
    }
}
