using comment.microservice.Data;
using comment.microservice.Repositories;
using comment.microservice.Services;
using CommentApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var stringConnection = builder.Configuration.GetConnectionString("defaultConnection");

//database
builder.Services.AddDbContext<CommentContext>(s => s.UseSqlServer(stringConnection));


//Mapper
builder.Services.AddAutoMapper(assemblies:AppDomain.CurrentDomain.GetAssemblies());

//Repository
builder.Services.AddTransient<ICommentRepository, CommentRepository>();


//Grpc

builder.Services.AddGrpc();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    
}

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGrpcService<CommentGrpcService>();

app.Run();


