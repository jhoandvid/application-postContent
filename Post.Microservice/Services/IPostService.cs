using Post.Microservice.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.Services
{
    public interface IPostService
    {
        public Task<ApiResponse<List<PostDto>>> GetAllPost();

        public Task<ApiResponse<PostDto>> GetPostById(int id);
        public Task<ApiResponse<object>> CreatePost(CreatePost post);

        public Task<ApiResponse<object>> DeletePost(int id);


    }
}
