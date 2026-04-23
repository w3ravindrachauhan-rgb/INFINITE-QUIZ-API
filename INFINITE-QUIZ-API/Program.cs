using INFINITE_QUIZ_API.Repository;
using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using INFINITE_QUIZ_API.DataProvider;
using INFINITE_QUIZ_API.Services.Interface;
using INFINITE_QUIZ_API.Services.Services; // Add this using directive for UseSqlServer extension method

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuizDal, QuizDal>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins(allowedOrigins ?? Array.Empty<string>())
            .AllowAnyHeader()
            .AllowAnyMethod());
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<QUIZDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ensure UseSqlServer is resolved

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseRouting();
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
