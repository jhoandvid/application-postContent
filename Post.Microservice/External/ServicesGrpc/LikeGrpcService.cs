using AutoMapper;
using like.microservice;
using Post.Microservice.Dtos.externalDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.External.ServicesGrpc
{

    public class LikeGrpcService:ILikeGrpcService
    {
        readonly IMapper _mapper;
        private readonly likeGrpc.likeGrpcClient _likeGrpcClient;

        public LikeGrpcService(IMapper mapper, likeGrpc.likeGrpcClient likeGrpcClient)
        {
            _mapper= mapper;
            _likeGrpcClient = likeGrpcClient;
        }

        public async Task<int> CountLikeByComment(int commentId)
        {
            var countLikeByCommentRequest = new CountLikeByCommentRequest() { CommentId=commentId};
            var countLikeComment=await _likeGrpcClient.CountLikeByCommentAsync(countLikeByCommentRequest);
            return countLikeComment.CountLikeComment;
        }

        public async Task<int> CountLikeByPost(int postId)
        {
            var countLikeByPostRequest = new CountLikeByPostRequest() { PostId = postId };
            var countLikePost = await _likeGrpcClient.CountLikeByPostAsync(countLikeByPostRequest);
            return countLikePost.CountLikePost;
        }

        public  async Task CreateLike(CreateLikeDto likeDto)
        {
            var createLikeRequest = _mapper.Map<CreateLikeRequest>(likeDto);
            await _likeGrpcClient.CreateLikeAsync(createLikeRequest);
            
        }

        public Task DeleteLikeComment(int commentId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLikePost(int postId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task CountLikeByComments(List<CommentDto> comments)
        {
            foreach (var commentDto in comments)
            {
                commentDto.CountLike = await this.CountLikeByComment(commentDto.Id);

                if (commentDto.ContentsParents != null && commentDto.ContentsParents.Any())
                {

                    await this.CountLikeByComments(commentDto.ContentsParents);

                }
            }
        }
    }

    
}
