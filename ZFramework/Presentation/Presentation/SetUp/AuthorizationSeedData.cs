using Application.SetUp.Model;
using Domain.Context;
using Domain.Entites;
using Domain.Entites.Base;
using Humanizer.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Presentation.Controllers;
using SixLabors.ImageSharp;
using System.Reflection;

namespace Presentation.SetUp
{
	public static class AuthorizationSeedData
	{

		public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
		{
			ProjectDetails projectDetails = configuration.GetSection(nameof(ProjectDetails)).Get<ProjectDetails>();

			services.AddSwaggerGen(c =>
			{
				c.EnableAnnotations();
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = projectDetails.Title,
					Version = projectDetails.Version.ToString(),

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
		public static void AuthorizationControllerSeedData(ApplicationDBContext context, Assembly assembly, IConfiguration configuration)
		{
			ProjectDetails projectDetails = configuration.GetSection(nameof(ProjectDetails)).Get<ProjectDetails>();




			var controlleractionlist = assembly.GetTypes()
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
			).FirstOrDefault().ToString().Split(".").LastOrDefault().Replace("Http", "").Replace("Attribute", "")
			})
			.OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

			List<Permission> lstPermisson = context.Permissions.AsNoTracking().ToList();

			controlleractionlist.ForEach(p =>
			{
				var existing = lstPermisson.FirstOrDefault(s =>
					s.ProjectName == projectDetails.Title &&
					s.ControllerName == p.Controller &&
					s.ActionName == p.Action &&
					s.ActionMethod == p.ActionMethod);

				if (existing == null)
				{
					// ایجاد
					context.Permissions.Add(new Permission
					{
						ProjectName = projectDetails.Title,
						ControllerName = p.Controller,
						ActionName = p.Action,
						ActionMethod = p.ActionMethod,
						CreateDateTime = DateTime.Now,
						IsActivee = true,
					});
				}
				else if (!existing.IsActivee)
				{
					// فعال‌سازی مجدد
					existing.IsActivee = true;
					existing.ModifyDateTime = DateTime.Now;
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
						ModifyDateTime = DateTime.Now,
						IsActivee = false,
					};

					context.Permissions.Update(permission);


				}
			});

			context.SaveChanges();
		}
	}
}
