using AutoMapper;
using CategoryApi;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Hosting;
using Post.Microservice.Dtos;
using Post.Microservice.Dtos.externalDto;
using Post.Microservice.External;
using Post.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _repository;
        private readonly ICategoryGrpcService _categoryGrpcService;
        private readonly ICommentGrpcService _commentGrpcService;
        
        public PostService(IMapper mapper, IPostRepository repository, ICategoryGrpcService categoryGrpcService, ICommentGrpcService commentGrpcService) {
            _repository = repository;
            _mapper = mapper;
            _categoryGrpcService = categoryGrpcService;
            _commentGrpcService = commentGrpcService;
        }
        public async Task<ApiResponse<List<PostDto>>> GetAllPost()
        {


            var posts = await _repository.GetAllPost();
            var postsDto = _mapper.Map<List<PostDto>>(posts);
             
            foreach (var post in postsDto)
            {
                post.Categories =await _categoryGrpcService.GetAllCategoriesByIds(post);
                post.Comments = new List<CommentDto>();
                post.CountComments=await _commentGrpcService.CountCommentByPost(post.Id);
            }
            return new ApiResponse<List<PostDto>> () { Issuccess = true, Messague = "Ok", Result = postsDto }; ;
        }

        public async Task<ApiResponse<object>> CreatePost(CreatePost post)
        {
            var categoriesIds= post.Categories.Distinct().ToList();
            post.Categories = categoriesIds;

            var categoriesDb= await _categoryGrpcService.GetAllCategoriesByIds(_mapper.Map<PostDto>(post));

            //Validation Categories
            var validCategories = _categoryGrpcService.ValidCategoriesByIds(categoriesDb, categoriesIds);

           

            if (!validCategories.Issuccess)
            {
                return new ApiResponse<object>() { Issuccess = false, Messague = "Error al guardar las categorias, las categorias con los siguientes ids no existen", Result = validCategories.Result }; ;
            }

            var postModel = await _repository.CreatePost(post);

            var postDto = _mapper.Map<PostDto>(postModel);

            postDto.Categories = categoriesDb;

            return  new ApiResponse<object>() { Issuccess = true, Messague = "Ok", Result = postDto };
        }


        public async Task<ApiResponse<PostDto>> GetPostById(int id)
        {
            var post=await _repository.GetPostById(id);

            if (post == null)
            {
                return new ApiResponse<PostDto>() { Issuccess = false, Messague = "El post no fue encontrado", Result = null }; ;
            }

            var postDto= _mapper.Map<PostDto>(post);
            var categoriesDb = await _categoryGrpcService.GetAllCategoriesByIds(postDto);
            var comments = await _commentGrpcService.GetAllCommentByPost(id);
            postDto.Categories= categoriesDb;
            postDto.Comments = comments;
            postDto.CountComments = comments.Count;

            return new ApiResponse<PostDto>() { Issuccess = true, Messague = "Ok", Result = postDto };
        }

        public async Task<ApiResponse<object>> DeletePost(int id)
        {
           var isDelete=await _repository.DeletePost(id);
            if (!isDelete)
            {
                return new ApiResponse<object>() { Issuccess=false, Messague="El post no fue encontrado", Result=null};
            }

            return new ApiResponse<object>() { Issuccess = true, Messague = "Ok", Result = null };
        }

     






    }
}
