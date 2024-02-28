using AutoMapper;
using post.microservice.Dto;
using post.microservice.models;
using post.microservice.repository;
using User.Microservice.Rabbit;

namespace post.microservice.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRabbitMQ _rabbitMq;
        public UserService(IUserRepository userRepository, IMapper mapper, IRabbitMQ rabbitMQ) { 
            _userRepository = userRepository;
            _mapper = mapper;
            _rabbitMq = rabbitMQ;
        }
        public Task<List<UserDto>> GetAllUsers()
        {
            throw new NotImplementedException();
        }


        public async Task<UserDto> GetById(int id)
        {
            var userModel = await _userRepository.GetById(id);
            if(userModel == null)
            {
                return null;
            }
            var userDto=_mapper.Map<UserDto>(userModel);
            
            return userDto;
        }

        public Task<UserDto> Login(LoginUserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> Register(RegisterUserDto user)
        {
            var userModelRegister = _mapper.Map<UserModel>(user);

            var userModel= await _userRepository.Register(userModelRegister);
            var userDto= _mapper.Map<UserDto>(userModel);
            return userDto;
        }
    }
}
