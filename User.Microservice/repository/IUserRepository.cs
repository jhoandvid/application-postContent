using post.microservice.Dto;
using post.microservice.models;

namespace post.microservice.repository
{
    public interface IUserRepository
    {
        public Task<List<UserModel>> GetAllUsers();

        public Task<UserModel> GetById(int id);
        public Task<UserModel> Login(LoginUserDto user);
        public Task<UserModel> Register(UserModel user);
    }
}
