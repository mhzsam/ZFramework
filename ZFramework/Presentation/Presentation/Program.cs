using Application.Helper;
using Application.MiddleWare;
using Application.SetUp;
using Domain.Context;
using Infrastructure.SetUp;
using System.Reflection;
using Presentation.SetUp;
using Microsoft.EntityFrameworkCore;
using Domain.Common.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AppSettings>(builder.Configuration);
var appSettings = builder.Configuration.Get<AppSettings>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
string connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddApplicationDBContext(connectionString);
builder.Services.AddJWTConfig(builder.Configuration);
builder.Services.AddJWT();
builder.Services.AddAllApplicationServices();
builder.Services.AddInfrastructureService();
builder.Services.AddDataAnnotationReturnData();
builder.Services.AddCors(o =>
{
	o.AddDefaultPolicy(p => p.AllowAnyOrigin()
							 .AllowAnyHeader()
							 .AllowAnyMethod()
							 );
});

builder.Services.SetupPresentation(appSettings);
var app = builder.Build();

app.UseCors();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<ApplicationDBContext>();
//    if (context.Database.GetPendingMigrations().Any())
//    {
//        context.Database.Migrate();
//    }
//}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UsePermissionCheck();

app.Run();
