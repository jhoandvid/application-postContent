

using System;
using System.Collections.Generic;

namespace Post.Microservice.Dtos.externalDto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public bool IsActive { get; set; }
        public string Content { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? ContentParentId { get; set; }
        public List<CommentDto> ContentsParents { get; set; }
    }
}
