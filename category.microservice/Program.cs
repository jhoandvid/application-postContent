using category.microservice.Data;
using category.microservice.Repository;
using category.microservice.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("defaultConnection");

builder.Services.AddDbContext<CategoryContext>(x => x.UseSqlServer(connectionString));

//Grpc
builder.Services.AddGrpc();

//Repository
builder.Services.AddTransient<ICategoryReposity,CategoryRepository>();

//Services
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
   // app.UseSwagger();
   // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGrpcService<CategoryService>();

app.Run();
