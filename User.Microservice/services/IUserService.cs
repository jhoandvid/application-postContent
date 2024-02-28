using post.microservice.Dto;

namespace post.microservice.services
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetAllUsers();

        public Task<UserDto> GetById(int id);
        public Task<UserDto> Login(LoginUserDto user);
        public Task<UserDto> Register(RegisterUserDto user);
    }
}
