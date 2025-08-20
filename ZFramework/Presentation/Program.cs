using Domain.Shared.Models;
using Infrastructure.Middleware;
using Microsoft.EntityFrameworkCore;
using Infrastructure.SetUp;
using Presentation.SetUp;
using Application.SetUp;
using Microsoft.Extensions.Configuration;
using Infrastructure.Context;

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
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

	try
	{
		var ff = context.Users.FirstOrDefault();
		Console.WriteLine("⏳ در حال تست اتصال EF Core ...");
		bool canConnect = context.Database.CanConnect();
		Console.WriteLine(canConnect
			? "✅ اتصال EF Core موفق بود!"
			: "❌ اتصال EF Core برقرار نشد.");
	}
	catch (Exception ex)
	{
		Console.WriteLine("❌ خطای اتصال دیتابیس:");
		Console.WriteLine(ex.Message);
		Console.WriteLine("------ StackTrace ------");
		Console.WriteLine(ex.StackTrace);

		if (ex.InnerException != null)
		{
			Console.WriteLine("------ InnerException ------");
			Console.WriteLine(ex.InnerException.Message);
			Console.WriteLine(ex.InnerException.StackTrace);
		}
	}
}
app.UseAppMiddlewares();
app.Run();
