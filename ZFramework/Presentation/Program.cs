using Application.SetUp;
using Domain.Helper;
using Domain.Shared.Models;
using Infrastructure.SetUp;
using Presentation.SetUp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AppSettings>(builder.Configuration);
var appSettings = builder.Configuration.Get<AppSettings>();
SecurityHelper.Configure(appSettings);

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
//using (var scope = app.Services.CreateScope())
//{
//	try
//	{
//		var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

//		Console.WriteLine("Testing database connection...");
//		await context.Database.OpenConnectionAsync();
//		Console.WriteLine("✅ Database connection successful!");
//		await context.Database.CloseConnectionAsync();

//		// تست ایجاد دیتابیس
//		bool canConnect = await context.Database.CanConnectAsync();
//		Console.WriteLine($"Can connect to database: {canConnect}");

//		// بررسی وجود دیتابیس و ایجاد آن در صورت عدم وجود
//		await context.Database.EnsureCreatedAsync();
//		Console.WriteLine("✅ Database ensured created!");
//	}
//	catch (Exception ex)
//	{
//		Console.WriteLine($"❌ Database connection failed: {ex.Message}");
//		Console.WriteLine($"❌ Inner exception: {ex.InnerException?.Message}");
//	}
//}

app.UseAppMiddlewares();
app.Run();
