using AutoMapper;
using comment.microservice.Dtos;
using comment.microservice.Model;
using comment.microservice.Repositories;
using CommentApi;
using Grpc.Core;
using System.Collections;

namespace comment.microservice.Services
{
    public class CommentGrpcService:CommentGrpc.CommentGrpcBase
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;
       
        public CommentGrpcService(ICommentRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async override Task<ResponseCreate> CreateComment(CommentCreateRequest request, ServerCallContext context)
        {
           
       
            var response = new ResponseCreate() { };
            var commenCreateDto = _mapper.Map<CreateCommentDto>(request);
            var commentModel = _mapper.Map<CommentModel>(commenCreateDto);
           
            await _repository.CreateComment(commentModel);
            return response;
    }



        public override async Task<GetCommentResponse> GetAllComment(GetCommentRequest request, ServerCallContext context)
        {
                
            var response = new GetCommentResponse();

            var idPost= request.PostId;
            var comments = await _repository.GetAllCommentsByPost(idPost);  
            var countComment= await _repository.CountCommentByPost(idPost);
            response.Count = countComment;
            var commentGrpc = _mapper.Map<List<GrpcCommentModel>>(comments);
            response.Comment.AddRange(commentGrpc);
    
            return response;

        }

        public override async Task<GRPCommentDeleteResponse> DeleteComment(GRPCommentDeleteRequest request, ServerCallContext context)
        {
            var response = new GRPCommentDeleteResponse();

                
           var resposeDelete= await _repository.DeleteComment(request.PostId ,request.Id, request.UserId);

            response.IsSuccess = resposeDelete.IsSuccess;
            response.Message = resposeDelete.Messague;

            return response;


        }

        public override async Task<GetCommentByIdResponse> GetCommentById(GetCommentByIdRequest request, ServerCallContext context)
        {
            var response= new GetCommentByIdResponse();
            var comment = await _repository.GetCommentById(request.Id);
            
            var commentResponse=_mapper.Map<GrpcCommentModel>(comment);
            response.Comment = commentResponse;
            return response;
        }

        public override async Task<GetCountCommentResponse> CountCommentByPostId(GetCountCommentRequest request, ServerCallContext context)
        {
            var getCountCommentResponse=new GetCountCommentResponse();
            var countComment = await _repository.CountCommentByPost(request.PostId);

            getCountCommentResponse.CountComment=countComment;

            return getCountCommentResponse;

        }




    }

}
