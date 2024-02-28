using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Post.Microservice.Dtos.externalDto;

namespace Post.Microservice.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get;set; }
        public int CountComments { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public bool IsActive { get; set; }
     }
}
