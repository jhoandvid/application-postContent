using AutoMapper;
using CategoryApi;
using CommentApi;
using Post.Microservice.Dtos;
using Post.Microservice.Dtos.externalDto;
using Post.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.mapping
{
    public class MappingProfile:Profile
    {

        public MappingProfile() {

            CreateMap<PostModel, PostDto>().ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.PostCategories)).ReverseMap();

            CreateMap<PostCategoryModel, CategoryDto>().ReverseMap();


            CreateMap<GrpcCommentModel, CommentDto>().ForMember(dest => dest.ContentsParents, opt => opt.MapFrom(src => src.ContentParents)).ReverseMap();


            CreateMap<CreatePost, PostDto>()
           .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(id => new PostCategoryModel { IdCategory = id })));


            CreateMap<GetCategoryResponse, CategoryDto>().ReverseMap();

            CreateMap<CreatePost, PostModel>()
           .ForMember(dest => dest.PostCategories, opt => opt.MapFrom(src => src.Categories.Select(id => new PostCategoryModel { IdCategory=id })))
           .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.UserId))
           .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
           .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
           .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));



        }


    }
}
