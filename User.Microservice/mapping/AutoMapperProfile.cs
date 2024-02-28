using AutoMapper;
using post.microservice.Dto;
using post.microservice.models;

namespace User.Microservice.mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() {

            CreateMap<UserModel, UserDto>().ReverseMap();

            CreateMap<RegisterUserDto, UserModel>();
            
        }
    }
}
