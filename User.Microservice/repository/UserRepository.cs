using Microsoft.EntityFrameworkCore;
using post.microservice.Dto;
using post.microservice.models;
using User.microservice.Data;

namespace post.microservice.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context) { 
            _context= context;
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
           var users=await _context.Users.ToListAsync();
            return users;
        }

        public async Task<UserModel> GetById(int id)
        {
            var user= await _context.Users.FirstOrDefaultAsync(x=>x.Id==id);
            return user;
        }

        public Task<UserModel> Login(LoginUserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> Register(UserModel user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
