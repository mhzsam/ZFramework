using Domain.Entites;
using Domain.Shared.Message;
using Domain.Shared.Models;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Presentation.Controllers;
using SixLabors.ImageSharp;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Presentation.SetUp
{
	public static class Setup
	{
		public static IServiceCollection SetupPresentationLayer(this IServiceCollection services, AppSettings appSettings)
		{

			services.AddSwagger(appSettings);
			services.AuthorizationControllerSeedData(appSettings);
			services.AddJWT(appSettings);

			return services;
		}
		private static IServiceCollection AddSwagger(this IServiceCollection services, AppSettings appSettings)
		{

			ProjectDetails projectDetails = appSettings.ProjectDetails;

			services.AddSwaggerGen(c =>
			{
				c.EnableAnnotations();
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = projectDetails.Title,
					Version = projectDetails.ToString(),

				});

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					},
					Scheme = "Bearer",
					Name = "Authorization",

					In = ParameterLocation.Header,
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement {
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					},
					new string[] { }
				}
				});

			});

			return services;
		}
		private static void AuthorizationControllerSeedData(this IServiceCollection services, AppSettings appSettings)
		{

			AplicationDBContext context = services.BuildServiceProvider().GetRequiredService<AplicationDBContext>();
			ProjectDetails projectDetails = appSettings.ProjectDetails;

			//var tableExists = context.Database.CanConnect() &&
			//			 context.Model.FindEntityType(typeof(Permission)) != null;

			//if (!tableExists)
			//	return;


			var controlleractionlist = Assembly.GetExecutingAssembly().GetTypes()
			.Where(type => typeof(BaseController).IsAssignableFrom(type))
			.SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
			.Select(x => new
			{
				Controller = x.DeclaringType.Name,
				Action = x.Name,
				ActionMethod = x.GetCustomAttributes().Where(attr =>
			attr.GetType() == typeof(HttpGetAttribute)
			|| attr.GetType() == typeof(HttpPutAttribute)
			|| attr.GetType() == typeof(HttpPostAttribute)
			|| attr.GetType() == typeof(HttpDeleteAttribute)
			).FirstOrDefault().ToString().Split(".").LastOrDefault().Replace("Http", "").Replace("Attribute", ""),
				Description = x.GetCustomAttribute<DescriptionAttribute>()?.Description

			})
			.OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

			List<Permission> lstPermisson = context.Permissions.AsNoTracking().ToList();

			controlleractionlist.ForEach(p =>
			{
				var existing = lstPermisson.FirstOrDefault(s =>
					s.ProjectName == projectDetails.Title &&
					s.ControllerName == p.Controller &&
					s.ActionName == p.Action &&
					s.ActionMethod == p.ActionMethod
					);

				if (existing == null)
				{
					// ایجاد
					var permission = new Permission
					{
						ProjectName = projectDetails.Title,
						ControllerName = p.Controller,
						ActionName = p.Action,
						ActionMethod = p.ActionMethod,
						InsertDate = DateTime.Now,
						IsActivee = true,
						Description = p.Description
					};
					permission.ComputeAndSetHash();
					context.Permissions.Add(permission);
				}
				else if (!existing.IsActivee || existing.Description != p.Description)
				{
					// فعال‌سازی مجدد
					existing.IsActivee = true;
					existing.UpdateDate = DateTime.Now;
					existing.UpdateBy = -1;
					existing.Description = p.Description;
					context.Permissions.Update(existing);
				}
			});

			lstPermisson.ForEach(p =>
			{
				if (!controlleractionlist.Any(s => p.ProjectName == projectDetails.Title &&
							   p.ControllerName == s.Controller &&
							   p.ActionName == s.Action &&
							   p.ActionMethod == s.ActionMethod
							))
				{
					var permission = new Permission
					{
						Id = p.Id,
						ProjectName = projectDetails.Title,
						ControllerName = p.ControllerName,
						ActionName = p.ActionName,
						ActionMethod = p.ActionMethod,
						UpdateDate = DateTime.Now,
						UpdateBy = -1,
						IsActivee = false,
						Description = p.Description
					};
					permission.ComputeAndSetHash();
					context.Permissions.Update(permission);


				}
			});

			context.SaveChanges();
		}
		private static IServiceCollection AddJWT(this IServiceCollection services, AppSettings appSettings)
		{

			JwtConfig configs = appSettings.JWTConfig;
			var key = Encoding.UTF8.GetBytes(configs.TokenKey);


			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ClockSkew = TimeSpan.FromMinutes(configs.TokenTimeOut),
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
				x.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
				{
					OnChallenge = async context =>
					{
						context.HandleResponse(); // جلوگیری از پاسخ پیش‌فرض
						context.Response.StatusCode = StatusCodes.Status401Unauthorized;
						context.Response.ContentType = ContentTypes.Json;
						var response = ResponseModel.Fail(ErrorText.Auth.Unauthorized);
						await context.Response.WriteAsJsonAsync(response);
					},
					OnForbidden = async context =>
					{
						context.Response.StatusCode = StatusCodes.Status403Forbidden;
						context.Response.ContentType = ContentTypes.Json;
						var response = ResponseModel.Fail(ErrorText.Auth.Unauthorized);
						await context.Response.WriteAsJsonAsync(response);
					}
				};
			});

			return services;
		}
	}
}
