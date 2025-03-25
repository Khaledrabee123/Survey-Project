using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Survay.Models.database;
using MediatR;
using Serilog;

namespace Survay
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			// Add services to the container.
			builder.Services.AddControllersWithViews();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
            builder.Services.AddMemoryCache();


            builder.Services.AddSerilog();
            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddDbContext<db>(OptionsBuilder =>
			{
				OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
			});

			builder.Services.AddIdentity<User, IdentityRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = true;
			})
			.AddEntityFrameworkStores<db>()
			 .AddDefaultTokenProviders(); // This li
			builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
			{
				options.TokenLifespan = TimeSpan.FromHours(3); // Set token expiration time as needed
			});

			builder.Services.AddAuthentication().AddGoogle(options =>
			{
				var googleAuthSettings = builder.Configuration.GetSection("Authentication:Google");
				options.ClientId = googleAuthSettings["ClientId"];
				options.ClientSecret = googleAuthSettings["ClientSecret"];
			});




			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
