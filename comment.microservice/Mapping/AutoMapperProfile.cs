using AutoMapper;
using comment.microservice.Dtos;
using comment.microservice.Model;
using CommentApi;
using Google.Protobuf.WellKnownTypes;

namespace comment.microservice.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
         
            CreateMap<CreateCommentDto, CommentModel>()
                .ForMember(dest => dest.ContentParentId, opt => opt.MapFrom(src => src.ContentParentId == 0 ? null : src.ContentParentId));

            CreateMap<GrpcCommentModel, CommentModel>()
           .ForMember(dest => dest.ContentsParents, opt => opt.MapFrom(src => src.ContentParents))
           .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt == null ? (DateTime?)null : src.CreateAt.ToDateTime().ToUniversalTime()))
           .ForMember(dest => dest.UpdateAt, opt => opt.MapFrom(src => src.UpdateAt == null ? (DateTime?)null : src.UpdateAt.ToDateTime().ToUniversalTime()))
           .ReverseMap()
           .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt == null ? null : Timestamp.FromDateTime(src.CreateAt.Value.ToUniversalTime())))
           .ForMember(dest => dest.UpdateAt, opt => opt.MapFrom(src => src.UpdateAt == null ? null : Timestamp.FromDateTime(src.UpdateAt.Value.ToUniversalTime())));

            //CreateMap<GrpcCommentModel, CommentModel>().ForMember(dest => dest.ContentsParents, opt => opt.MapFrom(src => src.ContentParents)).ForMember(dest=>dest.CreateAt, opt=>opt.MapFrom(src=> Timestamp.FromDateTime(src.CreateAt))).ReverseMap();

            CreateMap<CommentCreateRequest, CreateCommentDto>();


        }
    }
}
