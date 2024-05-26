using DemoProject_DataAccess.Data;
using DemoProject_WebAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
	c.AddPolicy("AllowOrigin", options => options
						.SetIsOriginAllowedToAllowWildcardSubdomains()
						.WithOrigins("http://192.168.49.2:3000")
						.AllowAnyMethod()
						.AllowCredentials()
						.AllowAnyHeader()
						.Build());
});

RegisterService.RegisterComponent(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.MapFallbackToController("Index", "Fallback");
app.Run();
