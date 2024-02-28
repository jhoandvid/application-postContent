using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Post.Microservice.Dtos;
using Post.Microservice.Dtos.externalDto;
using Post.Microservice.External;

namespace Post.Microservice
{
    public class CommontFuncion
    {
        private readonly ILogger<CommontFuncion> _logger;

        private readonly ICommentGrpcService _commentService;

        public CommontFuncion(ILogger<CommontFuncion> log, ICommentGrpcService commentGrpcService)
        {
            _logger = log;
            _commentService = commentGrpcService;
        }


        [FunctionName("CreateComment")]
        [OpenApiOperation(operationId: "CreatePost", tags: new[] { "Comment" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(void), Description = "The OK response")]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(CreateCommentDto))]
        public async Task<IActionResult> CreateComment(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] CreateCommentDto createComment)
        {
         var comment=   await _commentService.CreateComment(createComment);
         if(comment != null) {
                return new BadRequestObjectResult(comment);
            }
            return new NoContentResult();
        }



        [FunctionName("DeleteCommentPost")]
        [OpenApiOperation(operationId: "DeleteCommentPost", tags: new[] { "Comment" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<object>), Description = "The OK response")]
        [OpenApiParameter(name:"id")]
        [OpenApiParameter(name: "idUser")]
        [OpenApiParameter(name: "idPost")]
        public async Task<IActionResult> DeleteCommentPost(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeleteCommentPost/post/{idPost:int}/comment/{id:int}/user/{idUser:int}")] HttpRequest req, int idPost, int id, int idUser)
        {
            var response= await _commentService.DeleteComment(idPost, id, idUser);
            if (response.Issuccess == false)
            {
                return new NotFoundObjectResult(response);
            }
            return new OkObjectResult(response);
        }






    }
}

