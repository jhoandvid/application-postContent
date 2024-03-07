using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Post.Microservice.Dtos.externalDto
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum TypeLikeEnum
    {
        post,
        comment
    }
}
