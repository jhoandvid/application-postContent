using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Post.Microservice.Dtos;
using Post.Microservice.Dtos.externalDto;
using Post.Microservice.External;
using Post.Microservice.Services;

namespace Post.Microservice
{
    public class PostFunction
    {
        private readonly ILogger<PostFunction> _logger;
        private readonly IPostService _postService;
        private readonly ICommentGrpcService _commentService;

        public PostFunction(ILogger<PostFunction> log, IPostService postService, ICommentGrpcService commentService)
        {
            _postService = postService;
            _commentService = commentService;
            _logger = log;
        }

        [FunctionName("CreatePost")]
        [OpenApiOperation(operationId: "CreatePost", tags: new[] { "Post" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<PostDto>), Description = "The OK response")]
        [OpenApiRequestBody(contentType:"application/json", bodyType:typeof(CreatePost))]
        public async Task<IActionResult> CreatePost(
            [HttpTrigger(AuthorizationLevel.Anonymous,  "post", Route = null)] CreatePost createPost)
        {
            var reponse = await _postService.CreatePost(createPost);

            if (!reponse.Issuccess)
            {
                return new BadRequestObjectResult(reponse);
            }


            return new OkObjectResult(reponse.Result);
        }

        [FunctionName("GetAllPost")]
        [OpenApiOperation(operationId: "GetAllPost", tags: new[] { "Post" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<List<PostDto>>), Description = "The OK response")]
        public async Task<IActionResult> GetAllPost(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var response = await _postService.GetAllPost();

            if (!response.Issuccess)
            {
                return new NotFoundObjectResult(response);
                
            }

            return new OkObjectResult(response);
        }

        [FunctionName("GetByIdPost")]
        [OpenApiOperation(operationId: "GetByIdPost", tags: new[] {"Post"})]
        [OpenApiParameter(name:"id")]
        [OpenApiResponseWithBody(statusCode:HttpStatusCode.OK,contentType:"application/json", bodyType:typeof(ApiResponse<PostDto>), Description = "The OK response")]
        public async Task<IActionResult> GetByIdPost([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetByIdPost/{id:int}")] HttpRequest req, int id) 
        {
            var response = await _postService.GetPostById(id);
            if (!response.Issuccess)
            {
                return new NotFoundObjectResult(response);
            }
            return new OkObjectResult(response);
        }

        [FunctionName("DeletePost")]
        [OpenApiOperation(operationId: "DeletePost", tags: new[] { "Post" })]
        [OpenApiParameter(name: "id")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<object>), Description = "The OK response")]
        public async Task<IActionResult> DeletePost([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeleteByIdPost/{id:int}")] HttpRequest req, int id)
        {
           var response= await _postService.DeletePost(id);
            if (!response.Issuccess)
            {
                return new NotFoundObjectResult(response);
            }
            return new OkObjectResult(response);
        }


    }
}

