using CommentApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Post.Microservice.Dtos.externalDto;
using AutoMapper;
using Post.Microservice.Dtos;

namespace Post.Microservice.External.ServicesGrpc
{
    public  class CommentGrpcService: ICommentGrpcService
    {
        private readonly CommentGrpc.CommentGrpcClient _commentGrpcClient;

        private readonly IMapper _mapper;

        public CommentGrpcService(CommentGrpc.CommentGrpcClient commentGrpcClient, IMapper mapper)
        {
            _commentGrpcClient= commentGrpcClient;
            _mapper= mapper;
        }

        public async Task<ApiResponse<CommentDto>> CreateComment(CreateCommentDto comment)
        {
            var commentRequest = new CommentCreateRequest() { Content= comment.Content, PostId= comment.PostId, UserId=comment.UserId};

            if (comment.ContentParentId>0)
            {
                commentRequest.ContentParentId = (int) comment.ContentParentId;
                
                var commentParentResponse= await this.GetCommentById(commentRequest.ContentParentId);

                if (!commentParentResponse.IsSuccess)
                {
                    return commentParentResponse;
                }
            }

            await _commentGrpcClient.CreateCommentAsync(commentRequest);

            return null;           
        }

        public async Task<ApiResponse<object>> DeleteComment(int idPost, int id, int idUser)
        {

            var reqGrpcComment = new GRPCommentDeleteRequest();
            
            reqGrpcComment.Id = id;
            reqGrpcComment.UserId = idUser;
            reqGrpcComment.PostId = idPost;
            var responseGrpc=await _commentGrpcClient.DeleteCommentAsync(reqGrpcComment);
            return new ApiResponse<object> { IsSuccess=responseGrpc.IsSuccess, Messague=responseGrpc.Message, Result=null };
        }

        public async Task<List<CommentDto>> GetAllCommentByPost(int idPost)
        {
            var commentRequest = new GetCommentRequest();
            commentRequest.PostId= idPost;
            var comments = await _commentGrpcClient.GetAllCommentAsync(commentRequest);
           
            var commentDb= _mapper.Map<List<CommentDto>>(comments.Comment);
            return commentDb;
        }

        public async Task<ApiResponse<CommentDto>> GetCommentById(int id)
        {
            var commenRequest = new GetCommentByIdRequest
            {
                Id = id
            };

            var responseComment= await this._commentGrpcClient.GetCommentByIdAsync(commenRequest);

            if(responseComment.Comment == null)
            {
                return new ApiResponse<CommentDto> { IsSuccess = false, Messague = "El comentario padre no se encontro", Result = null };
            }

            var commentDto = _mapper.Map<CommentDto>(responseComment.Comment);

            return new ApiResponse<CommentDto> { IsSuccess = true, Messague = "Ok", Result = commentDto};

        }

        public async Task<int> CountCommentByPost(int postId)
        {

            var getCountCommentRequest = new GetCountCommentRequest()
            {
                PostId = postId
            };

            var response= await _commentGrpcClient.CountCommentByPostIdAsync(getCountCommentRequest);
            return response.CountComment;
        }

     
    }


}
