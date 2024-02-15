using LearningAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using LearningAPI.Infraestructure.Users;
using LearningAPI.Application.RepositoryInterfaces;
using LearningAPI.Application.Interfaces.Services;
using LearningAPI.Application.Services;
using LearningAPI.Infraestructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Learning API", Version = "v1"});
    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = JwtBearerDefaults.AuthenticationScheme
        }
    );
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            new string[]{}
        }
    });
});

//Authentication 
builder.Services.AddAuthentication();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

builder.Services.AddAuthorizationBuilder()
  .AddPolicy("learning_api_policy", policy =>
        policy
            .RequireClaim("scope", "learning_api"));

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(dbConnectionString);
    }
);

//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Services
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

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
