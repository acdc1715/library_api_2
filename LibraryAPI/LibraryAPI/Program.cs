using LibraryAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

using LibraryAPI.DataAccess;
using BL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<LibraryDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDBConnectionString"))
//);

//builder.Services.AddSingleton<IBlobStorageService, BlobStorageService>();
//builder.Services.AddScoped<IAuthorRepository, SQLAuthorRepository>();
//builder.Services.AddScoped<IBookRepository, SQLBookRepository>();

//builder.Services.AddScoped<IAuthorsService, AuthorsService>();
//builder.Services.AddScoped<IBooksService, BooksService>();

//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddInfrastructureServices();
builder.Services.AddDataAccessServices(builder.Configuration.GetConnectionString("LibraryDBConnectionString"));
builder.Services.AddBLServices();

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
