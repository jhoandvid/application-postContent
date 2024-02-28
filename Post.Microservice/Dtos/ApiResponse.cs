using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Microservice.Dtos
{
    public class ApiResponse<T>
    {
        public bool Issuccess { get; set; }
        public string Messague { get; set; }
        public T? Result { get; set; }
    }
}
