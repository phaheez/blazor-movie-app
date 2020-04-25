using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorMovieApp.Areas.Identity;
using BlazorMovieApp.Data;
using BlazorMovieApp.Services;

namespace BlazorMovieApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("BlazorMovieAppConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddSingleton<WeatherForecastService>();
            services.AddTransient<IMovieDbService, MovieDbService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            CreateUserAndRoles(serviceProvider).Wait();
        }

        private async Task CreateUserAndRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //create admin
            var powerUser1 = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };
            var pwrd1 = "Admin@1234";
            var user1 = await userManager.FindByEmailAsync("admin@gmail.com");
            if (user1 == null)
            {
                var createUser1 = await userManager.CreateAsync(powerUser1, pwrd1);
                if (createUser1.Succeeded)
                {
                    await userManager.AddToRoleAsync(powerUser1, "Admin");
                }
            }

            //create user 1
            var powerUser2 = new IdentityUser
            {
                UserName = "test1@gmail.com",
                Email = "test1@gmail.com",
                EmailConfirmed = true
            };
            var pwrd2 = "Test@1234";
            var user2 = await userManager.FindByEmailAsync("test1@gmail.com");
            if (user2 == null)
            {
                var createUser2 = await userManager.CreateAsync(powerUser2, pwrd2);
                if (createUser2.Succeeded)
                {
                    await userManager.AddToRoleAsync(powerUser2, "User");
                }
            }

            // create user 2
            var powerUser3 = new IdentityUser
            {
                UserName = "test2@gmail.com",
                Email = "test2@gmail.com",
                EmailConfirmed = true
            };
            var pwrd3 = "Test@1234";
            var user3 = await userManager.FindByEmailAsync("test2@gmail.com");
            if (user3 == null)
            {
                var createUser3 = await userManager.CreateAsync(powerUser3, pwrd3);
                if (createUser3.Succeeded)
                {
                    await userManager.AddToRoleAsync(powerUser3, "User");
                }
            }
        }
    }
}
