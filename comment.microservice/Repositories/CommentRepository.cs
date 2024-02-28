using comment.microservice.Data;
using comment.microservice.Dtos;
using comment.microservice.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace comment.microservice.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CommentContext _context;

        public CommentRepository(CommentContext context)
        {
            _context = context;
        }
        public async Task CreateComment(CommentModel comment)
        {
     
            _context.AddRange(comment);
            await _context.SaveChangesAsync();
            

        }

        
        public async Task<List<CommentModel>> GetAllCommentsByPost(int PostId)
        {
           var allComment= await _context.Comments.Include(c=> c.ContentsParents).Where(c=>c.IsActive && c.PostId==PostId).ToListAsync();
           var mainComment = allComment.Where(c => c.ContentParentId==null).ToList();
            
            mainComment.ForEach(comment =>
            {

                comment.ContentsParents = allComment.Where(c => c.ContentParentId == comment.Id).ToList();
            });

            return mainComment;
        }

         public async  Task<CommentModel?> GetCommentById(int id)
        {
            var comment = await _context.Comments.Include(c=>c.ContentsParents).Where(c=>c.Id==id).FirstOrDefaultAsync();
            return comment;
        }

        private CommentModel? GetCommentByListCommentById(int id, List<CommentModel> comments)
        {
            
           foreach(var comment in comments) {
                if (comment.Id == id)
                {
                    return comment;
                }
                //Recursive search in all parent comments and child comments
                if (comment.ContentsParents!=null && comment.ContentsParents.Any())
                {
                    var findComment = this.GetCommentByListCommentById(id, comment.ContentsParents);
                    if(findComment != null)
                    {
                        return findComment;

                    }
                }
            }

            return null;
        }

        public async Task<int> CountCommentByPost(int PostId)
        {
            return await _context.Comments.Where(c=>c.PostId==PostId).CountAsync();
        }



        public async Task<ApiResponse> DeleteComment(int postId, int id, int userId)
        {

            var allCommentByPost = await this.GetAllCommentsByPost(postId);

            var comment = this.GetCommentByListCommentById(id, allCommentByPost);
            
            if (comment == null)
            {
                return new ApiResponse() { IsSuccess = false, Messague = $"No se encontro el comentario", Result = null };
            }

            if (comment.UserId != userId)
            {
                return new ApiResponse() { IsSuccess = false, Messague = $"No tiene permisos necesarios para eliminar el comentario", Result = null };

            }
 
              _context.Comments.Remove(comment);
                

            await _context.SaveChangesAsync();
            
            return new ApiResponse() { IsSuccess = true, Messague = "Ok", Result = null };

            
        }

       
    }
}
