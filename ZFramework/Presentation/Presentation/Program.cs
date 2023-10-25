using Application.Helper;
using Application.MiddleWare;
using Application.SetUp;
using Domain.Context;
using Infrastructure.SetUp;
using System.Reflection;
using Presentation.SetUp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddSwagger();
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p => p.AllowAnyOrigin()
                             .AllowAnyHeader()
                             .AllowAnyMethod()
                             );
});


var app = builder.Build();

app.UseCors();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDBContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
AuthorizationSeedData.AuthorizationControllerSeedData(
                    builder.Services.BuildServiceProvider()
                    .GetRequiredService<ApplicationDBContext>(),
                    Assembly.GetExecutingAssembly()
                    );

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UsePermissionCheck();

app.Run();
