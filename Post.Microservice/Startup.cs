using CategoryApi;
using CommentApi;
using like.microservice;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Post.Microservice.External;
using Post.Microservice.External.ServicesGrpc;
using Post.Microservice.Repository;
using Post.Microservice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.microservice.Data;

[assembly: FunctionsStartup(typeof(Post.Microservice.Startup))]
namespace Post.Microservice
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var stringConnection = Environment.GetEnvironmentVariable("ConnectionStrings");
            builder.Services.AddDbContext<PostContext>(x=>x.UseSqlServer(stringConnection));


            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddSwaggerGen(c =>
            {
            
                c.DescribeAllEnumsAsStrings();
            });

            //GRPC
            builder.Services.AddGrpcClient<CategoryGrpc.CategoryGrpcClient>((services, options) =>
            {
                options.Address = new Uri("https://localhost:7092");
            });

            builder.Services.AddGrpcClient<CommentGrpc.CommentGrpcClient>((services, options) =>
            {
                options.Address = new Uri("https://localhost:7234");
            });

            builder.Services.AddGrpcClient<likeGrpc.likeGrpcClient>((services, options) =>
            {
                options.Address = new Uri("http://localhost:5000");
            });


            builder.Services.AddTransient<IPostRepository, PostRepository>();

            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<ICategoryGrpcService, CategoryGrpcService>();
            builder.Services.AddScoped<ICommentGrpcService, CommentGrpcService>();
            builder.Services.AddScoped<ILikeGrpcService, LikeGrpcService>();

        }
    }
}
