using Post.Microservice.Dtos.externalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.Dtos
{
    public class CreatePost
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<int> Categories { get; set; }
        public bool IsActive { get; set; }
    }
}
