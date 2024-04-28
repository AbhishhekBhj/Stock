using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//adding controllers

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//adding db context

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{

    //use sql server as the db 

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); //connect with the databse with that particular connection string



});

//registering repository and interface
builder.Services.AddScoped<IStockRepository,CreateStockRepository>();
builder.Services.AddScoped<ICommentRepostiory, CommentRepostitoy>();

//builder.Services.AddScoped<ICommentRepostiory, CommentRepostitoy>();

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



app.Run(); //app runs from here
