using AutoMapper;
using Grpc.Core;
using like.microservice.Model;
using like.microservice.Repository;


namespace like.microservice.Services
{
    public class GrpcLikeService : likeGrpc.likeGrpcBase
    {
        private readonly ILogger<GrpcLikeService> _logger;
        private readonly IMapper _mapper;   
        private readonly ILikeRepository _likeRepository;
        public GrpcLikeService(ILogger<GrpcLikeService> logger, IMapper mapper, ILikeRepository likeRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _likeRepository = likeRepository;
        }

        public override async Task<CountLikeByCommentResponse> CountLikeByComment(CountLikeByCommentRequest request, ServerCallContext context)
        {

            var response = new CountLikeByCommentResponse() { };
            _logger.LogInformation("Obteniendo datos");
            var countLikeComment= await _likeRepository.CountLikeByComment(request.CommentId);
            response.CountLikeComment = countLikeComment;
               
            return response;

        }

        public override async Task<CountLikeByPostResponse> CountLikeByPost(CountLikeByPostRequest request, ServerCallContext context)
        {
            var response = new CountLikeByPostResponse() { };
            _logger.LogInformation("Obteniendo datos");
            var countLikePost = await _likeRepository.CountLikeByPost(request.PostId);
            response.CountLikePost = countLikePost;
            return response;
        }

        public override async Task<DeleteLikeByCommentResponse> DeleteLikeByComment(DeleteLikeByCommentRequest request, ServerCallContext context)
        {
            var response = new DeleteLikeByCommentResponse() { };
            _logger.LogInformation("Obteniendo datos");
            await _likeRepository.DeleteLikeComment(request.CommentId, request.UserId);
           
            return response;
        }


        public override async Task<DeleteLikeByPostResponse> DeleteLikeByPost(DeleteLikeByPostRequest request, ServerCallContext context)
        {
            var response = new DeleteLikeByPostResponse() { };
            _logger.LogInformation("Obteniendo datos");
            await _likeRepository.DeleteLikeComment(request.PostId, request.UserId);
            return response;
        }

        public override async Task<CreateLikeResponse> CreateLike(CreateLikeRequest request, ServerCallContext context)
        {
            var response= new CreateLikeResponse() { };
            var likeModel = _mapper.Map<LikeModel>(request);
            if (request.ContentType == "post")
            {
                var postLike = await _likeRepository.FindLikeById(request.PostId, request.ContentType, likeModel.UserId);
                if(postLike != null)
                {
                    await _likeRepository.DeleteLikePost(request.PostId, request.UserId);
                    return response;
                }

                if (likeModel.CommentId == 0)
                {
                    likeModel.CommentId = null;
                }

                await _likeRepository.CreateLike(likeModel);
                return response; 
            }


            if (request.ContentType == "comment")
            {
                var commentLike = await _likeRepository.FindLikeById(request.CommentId, request.ContentType, likeModel.UserId);
                if (commentLike != null)
                {
                    await _likeRepository.DeleteLikeComment(request.CommentId, request.UserId);
                    return response;
                }
                await _likeRepository.CreateLike(likeModel);
                return response;
            }


            return response;
        }


    }
}
