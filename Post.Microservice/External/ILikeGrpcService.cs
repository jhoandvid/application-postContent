using Post.Microservice.Dtos.externalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.External
{
    public interface ILikeGrpcService
    {
        public Task CreateLike(CreateLikeDto likeDto);
        public Task<int> CountLikeByPost(int postId);

        public Task<int> CountLikeByComment(int commentId);

        public Task DeleteLikeComment(int commentId, int userId);
        public Task DeleteLikePost(int postId, int userId);

        public Task CountLikeByComments(List<CommentDto> comments);
    }
}
