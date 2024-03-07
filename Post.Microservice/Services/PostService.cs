using AutoMapper;
using CategoryApi;
using Google.Protobuf;
using Grpc.Core;
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
        private readonly ILikeGrpcService _likeGrpcService;
        
        public PostService(IMapper mapper, IPostRepository repository, ICategoryGrpcService categoryGrpcService, ICommentGrpcService commentGrpcService, ILikeGrpcService likeGrpcService) {
            _repository = repository;
            _mapper = mapper;
            _categoryGrpcService = categoryGrpcService;
            _commentGrpcService = commentGrpcService;
            _likeGrpcService = likeGrpcService;
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
                post.Likes=await _likeGrpcService.CountLikeByPost(post.Id);
            }
            return new ApiResponse<List<PostDto>> () { IsSuccess = true, Messague = "Ok", Result = postsDto }; ;
        }

        public async Task<ApiResponse<object>> CreatePost(CreatePost post)
        {
            var categoriesIds= post.Categories.Distinct().ToList();
            post.Categories = categoriesIds;

            var categoriesDb= await _categoryGrpcService.GetAllCategoriesByIds(_mapper.Map<PostDto>(post));

            //Validation Categories
            var validCategories = _categoryGrpcService.ValidCategoriesByIds(categoriesDb, categoriesIds);

           

            if (!validCategories.IsSuccess)
            {
                return new ApiResponse<object>() { IsSuccess = false, Messague = "Error al guardar las categorias, las categorias con los siguientes ids no existen", Result = validCategories.Result }; ;
            }

            var postModel = await _repository.CreatePost(post);

            var postDto = _mapper.Map<PostDto>(postModel);

            postDto.Categories = categoriesDb;

            return  new ApiResponse<object>() { IsSuccess = true, Messague = "Ok", Result = postDto };
        }


        public async Task<ApiResponse<PostDto>> GetPostById(int id)
        {
            try
            {


                var post = await _repository.GetPostById(id);

                if (post == null)
                {
                    return new ApiResponse<PostDto>() { IsSuccess = false, Messague = "El post no fue encontrado", Result = null }; ;
                }

                var postDto = _mapper.Map<PostDto>(post);

                await this.EnrichPostDto(postDto);

                await _likeGrpcService.CountLikeByComments(postDto.Comments);

                return new ApiResponse<PostDto>() { IsSuccess = true, Messague = "Ok", Result = postDto };

            } catch (Exception ex)
            {
                throw;
                return new ApiResponse<PostDto>() { IsSuccess = false, Messague = "Ha ocurrido un error al procesar su solicitud", Result = null };
            }
        }


        private async Task EnrichPostDto(PostDto postDto)
        {
            try
            {

            
            var categoriesTask = _categoryGrpcService.GetAllCategoriesByIds(postDto);
            var commentsTask = _commentGrpcService.GetAllCommentByPost(postDto.Id);
            var likesTask = _likeGrpcService.CountLikeByPost(postDto.Id);

            await Task.WhenAll(categoriesTask, commentsTask, likesTask);

            var categoriesDb = await categoriesTask;
            var comments = await commentsTask;
            postDto.Categories = categoriesDb;
            postDto.Comments = comments;
            postDto.Likes = await likesTask;
            postDto.CountComments = comments.Count;
            }
            catch (RpcException rpcEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ApiResponse<object>> DeletePost(int id)
        {
           var isDelete=await _repository.DeletePost(id);
            if (!isDelete)
            {
                return new ApiResponse<object>() { IsSuccess =false, Messague="El post no fue encontrado", Result=null};
            }

            return new ApiResponse<object>() { IsSuccess = true, Messague = "Ok", Result = null };
        }

     






    }
}
