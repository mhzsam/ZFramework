using Domain.Shared.Models;
using Infrastructure.Middleware;
using Microsoft.EntityFrameworkCore;
using Infrastructure.SetUp;
using Presentation.SetUp;
using Application.SetUp;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AppSettings>(builder.Configuration);
var appSettings = builder.Configuration.Get<AppSettings>();

builder.Services.SetUpApplicationLayer(appSettings);
builder.Services.SetUpInfrastructureLayer(appSettings);
builder.Services.SetupPresentationLayer(appSettings);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(o =>
{
	o.AddDefaultPolicy(p => p.AllowAnyOrigin()
							 .AllowAnyHeader()
							 .AllowAnyMethod()
							 );
});

var app = builder.Build();

app.UseAppMiddlewares();
app.Run();
