using Api.Data.Context;
using Api.Data.Implemention;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Service.Category;
using Api.Domain.Interfaces.Service.List;
using Api.Domain.Interfaces.Service.Task;
using Api.Domain.Interfaces.Service.User;
using Api.Domain.Security;
using Api.Service.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IListService, ListService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IImplementionList, ImplementionListService>();
builder.Services.AddTransient<IUserLogon, LoginService>();
builder.Services.AddScoped<IUserLogonRepository, UserImplementation>();
builder.Services.AddScoped<IListRepository, ListImplemention>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

var signingConfiguration = new SigningConfiguration();
builder.Services.AddSingleton(signingConfiguration);

var tokenConfiguration = new TokenConfiguration();
new ConfigureFromConfigurationOptions<TokenConfiguration>(
    builder.Configuration.GetSection("TokenConfigurations"))
    .Configure(tokenConfiguration);

builder.Services.AddSingleton(tokenConfiguration);

builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(bearerOptions =>
    {
        var paramsValidation = bearerOptions.TokenValidationParameters;
        paramsValidation.IssuerSigningKey = signingConfiguration.Key;
        paramsValidation.ValidAudience = tokenConfiguration.Audience;
        paramsValidation.ValidIssuer = tokenConfiguration.Issuer;
        paramsValidation.ValidateIssuerSigningKey = true;
        paramsValidation.ValidateLifetime = true;
        paramsValidation.ClockSkew = TimeSpan.Zero;
    }
);

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser().Build());
});



var connectionString = "Server=localhost;Port=3306;Database=TaskAPI;Uid=root;Pwd=malengo@87";
builder.Services.AddDbContext<MyContext>(options =>

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Entre com o Token JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            }, new List<string>()
        }
    });
});

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
