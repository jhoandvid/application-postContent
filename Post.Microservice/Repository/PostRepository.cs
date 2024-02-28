using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Post.Microservice.Dtos;
using Post.Microservice.Model;
using Post.Microservice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.microservice.Data;

namespace Post.Microservice.Repository
{
    internal class PostRepository : IPostRepository
    {
        private readonly IMapper _mapper;
        private readonly PostContext _context;

        public PostRepository(PostContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<List<PostModel>> GetAllPost() {
            var posts = await _context.Posts.Include(e => e.PostCategories).Where(p=>p.IsActive).ToListAsync();
            return posts;

        }

        public async Task<PostModel> CreatePost(CreatePost post)
        {
            var postModel = _mapper.Map<PostModel>(post);
            _context.Add(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task<PostModel> GetPostById(int id)
        {
            var post = await _context.Posts.Include(c => c.PostCategories).Where(p => p.IsActive && p.Id == id).FirstOrDefaultAsync();
            return post;
        }

        public async Task<bool> DeletePost(int id)
        {
            var post = await this.GetPostById(id);
            if(post == null)
            {
                return false;
            }
            post.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
