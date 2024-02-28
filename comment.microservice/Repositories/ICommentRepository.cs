using comment.microservice.Dtos;
using comment.microservice.Model;

namespace comment.microservice.Repositories
{
    public interface ICommentRepository
    {
        public Task<List<CommentModel>> GetAllCommentsByPost(int idPost);
        public Task CreateComment(CommentModel comment);

        public Task<ApiResponse> DeleteComment(int idPost, int id, int userId);


        public Task<int> CountCommentByPost(int PostId);


        public Task<CommentModel?> GetCommentById(int id);


        




    }
}
