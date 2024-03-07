using like.microservice.Data;
using like.microservice.Repository;
using like.microservice.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<LikeContext>(s => s.UseSqlServer(
    builder.Configuration.GetConnectionString("defaultConnection")));


builder.Services.AddTransient<ILikeRepository,  LikeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GrpcLikeService>();

app.Run();
