
using Post.Microservice.Dtos;
using Post.Microservice.Dtos.externalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.External
{
    public interface ICommentGrpcService
    {
        public Task<List<CommentDto>> GetAllCommentByPost(int idPost);
        public Task<ApiResponse<CommentDto>> CreateComment(CreateCommentDto comment);

        public Task<ApiResponse<object>> DeleteComment(int idPost, int id, int idUser);

        public Task<int> CountCommentByPost(int postId);
        public Task<ApiResponse<CommentDto>> GetCommentById(int id);
    }
}
