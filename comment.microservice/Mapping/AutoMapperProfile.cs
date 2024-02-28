using AutoMapper;
using comment.microservice.Dtos;
using comment.microservice.Model;
using CommentApi;

namespace comment.microservice.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<CommentDto, CommentModel>().ReverseMap();
            CreateMap<CreateCommentDto, CommentModel>()
                .ForMember(dest => dest.ContentParentId, opt => opt.MapFrom(src => src.ContentParentId == 0 ? null : src.ContentParentId));

            CreateMap<GrpcCommentModel, CommentModel>().ForMember(dest => dest.ContentsParents, opt => opt.MapFrom(src => src.ContentParents)).ReverseMap();

            CreateMap<CommentCreateRequest, CreateCommentDto>();


        }
    }
}
