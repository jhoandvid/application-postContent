using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using post.microservice.repository;
using post.microservice.services;
using RabbitMQ.Client;
using User.microservice.Data;
using User.Microservice.Rabbit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var stringConnection = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(stringConnection));


ConfigureService(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureService(IServiceCollection services){

    var factory = new ConnectionFactory()
    {
        HostName = "localhost",
        UserName = "user",
        Password = "mypass",
        VirtualHost = "/",
    };

    services.AddSingleton<IRabbitMQ, RabbitMQService>();

    services.AddSingleton<IConnectionFactory>(factory);

    //Service
    builder.Services.AddScoped<IUserService, UserService>();

    //Repository
    builder.Services.AddTransient<IUserRepository, UserRepository>();
}