using Api.Data.Context;
using Api.Data.Implemention;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Service.Category;
using Api.Domain.Interfaces.Service.List;
using Api.Domain.Interfaces.Service.Task;
using Api.Domain.Interfaces.Service.User;
using Api.Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IListService, ListService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IImplementionList, ImplementionListService>();
builder.Services.AddScoped<IListRepository, ListImplemention>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));



var connectionString = "Server=localhost;Port=3306;Database=TaskAPI;Uid=root;Pwd=malengo@87";
builder.Services.AddDbContext<MyContext>(options =>

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
