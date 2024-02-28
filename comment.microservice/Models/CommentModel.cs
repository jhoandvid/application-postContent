using System;
using System.Collections.Generic;

namespace comment.microservice.Model
{
    public partial class CommentModel
    { 
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId {  get; set; }
        public int? ContentParentId { get; set; } = null;
        public string Content { get; set; }
        public DateTime? CreateAt { get; set; } 
        public bool IsActive { get; set; }
        public DateTime? UpdateAt { get; set; } 
        public virtual CommentModel? ContentParent { get; set; }
        public List<CommentModel> ContentsParents { get; set; }
    }
}
