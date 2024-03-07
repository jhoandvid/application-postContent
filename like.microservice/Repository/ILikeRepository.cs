using like.microservice.Model;

namespace like.microservice.Repository
{
    public interface ILikeRepository
    {
        public Task CreateLike(LikeModel likeModel);
        public Task<int> CountLikeByPost(int postId);

        public Task<int> CountLikeByComment(int commentId);
         
        public Task DeleteLikeComment(int commentId, int userId);
        public Task DeleteLikePost(int postId, int userId);
        public Task<LikeModel?> FindLikeById(int id, string type, int userId);



    }
}
