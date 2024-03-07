using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using like.microservice.Model;

namespace like.microservice.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<CreateLikeRequest, LikeModel>();
        }
    }
}
