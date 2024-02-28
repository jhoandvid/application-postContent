using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.Model
{
    public class PostCategoryModel
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public int IdPost { get; set; }

        public virtual PostModel IdPostNavigation { get; set; }
    }
}
