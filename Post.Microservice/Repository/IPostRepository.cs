using Post.Microservice.Dtos;
using Post.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.microservice.Data;

namespace Post.Microservice.Services
{
    public interface IPostRepository
    {
        public Task<List<PostModel>> GetAllPost();

        public Task<PostModel> GetPostById(int id);
        public Task<PostModel> CreatePost(CreatePost post);

        public Task<bool> DeletePost(int id); 

    }
}
