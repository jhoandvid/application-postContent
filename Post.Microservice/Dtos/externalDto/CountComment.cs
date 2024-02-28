using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.Dtos.externalDto
{
    public class CountComment
    {
        public int Count { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
