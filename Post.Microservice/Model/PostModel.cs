using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.Model
{
    public class PostModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<PostCategoryModel> PostCategories { get; set; }
        public bool IsActive { get; set; }

        


    }
}
