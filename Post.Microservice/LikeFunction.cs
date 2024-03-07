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
using Post.Microservice.Dtos.externalDto;
using Post.Microservice.External;

namespace Post.Microservice
{
    public class LikeFunction
    {
        private readonly ILikeGrpcService _likeGrpcService;
        private readonly ILogger<LikeFunction> _logger;

        public LikeFunction(ILogger<LikeFunction> log, ILikeGrpcService likeGrpcService)
        {
            _logger = log;
            _likeGrpcService = likeGrpcService;
        }

        [FunctionName("CreateLike")]
        [OpenApiOperation(operationId: "CreateLike", tags: new[] { "Likes" })]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(CreateLikeDto), Description = "The OK response")]
        public async Task<IActionResult> CreateLike(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "CreateLike")] CreateLikeDto createLikeDto)
        {
           await _likeGrpcService.CreateLike(createLikeDto);
            return new NoContentResult();
        }
    }
}

