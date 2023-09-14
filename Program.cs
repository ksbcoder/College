using AutoMapper.Data;
using College.AutoMapper;
using College.Business.IRepositories;
using College.Infrastructure.SQLServerAdapter.Gateway;
using College.Infrastructure.SQLServerAdapter.ReposImplementation;
using College.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration AutoMapper
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));

// Configuration SQL Server
var stringConnection = builder.Configuration.GetConnectionString("urlConnectionSQL");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(stringConnection));

//builder.Services.AddScoped<IDbConnectionBuilder, DbConnectionBuilder>();
builder.Services.AddScoped<ITeacher, TeacherImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Custom middleware
app.UseMiddleware<ErrorHandleMiddleware>();

app.MapControllers();

app.Run();
