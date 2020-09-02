using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyResume.Infrastructure;
using MyResume.Models;
using MyResume.Services;
using System;
using System.Text;

namespace MyResume
{
	public class Startup
	{
		readonly string AllowAllOriginsPolicy = "AllowAllOriginsPolicy";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
			services.AddSingleton(jwtTokenConfig);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = true;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidIssuer = jwtTokenConfig.Issuer,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
					ValidAudience = jwtTokenConfig.Audience,
					ValidateAudience = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.FromMinutes(1)
				};
			});
			services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
			services.AddHostedService<JwtRefreshTokenCache>();
			services.AddScoped<IUserService, UserService>();


			services.AddCors(options =>
			{
				options.AddPolicy(AllowAllOriginsPolicy, // I introduced a string constant just as a label "AllowAllOriginsPolicy"
				builder =>
				{
					builder.AllowAnyOrigin().AllowAnyHeader()
										.AllowAnyMethod();
				});
			});

			services.AddControllers();
			services.AddControllersWithViews();
			services.Configure<MyResumeDatabaseSettings>(
				Configuration.GetSection(nameof(MyResumeDatabaseSettings)));

			services.AddSingleton<IMyResumeDatabaseSettings>(sp =>
				sp.GetRequiredService<IOptions<MyResumeDatabaseSettings>>().Value);

			services.AddSingleton<AboutMeService>();
			services.AddSingleton<ExperienceService>();
			services.AddSingleton<SkillsService>();
			services.AddSingleton<HobbiesService>();
			services.AddSingleton<ProjectsService>();
			// In production, the React files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/build";
			});

			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseCors(AllowAllOriginsPolicy);

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();



			app.UseRouting();
			app.UseAuthorization();
			app.UseAuthentication();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseReactDevelopmentServer(npmScript: "start");
				}
				else
				{

					
				}
			});
		}
	}
}
