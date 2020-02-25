using System.Reflection;
using EShop.Application.Products.Queries.GetProducts;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.WebUI.HostedServices;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EShop.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                                                                options.UseSqlServer(connectionString));
            services.AddIdentity<ShopUser, IdentityRole>(options =>
                    {
                        options.User.RequireUniqueEmail = true;
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 6;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredUniqueChars = 0;
                    })
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMediatR(typeof(GetProductsQuery).GetTypeInfo().Assembly);

            services.AddControllersWithViews()
                    .AddNewtonsoftJson();
            services.AddRazorPages();

            services.AddHostedService<MigrationHostedService>()
                    .AddHostedService<CreateDefaultRolesHostedService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                                                 "Admin",
                                                 "Admin",
                                                 "Admin/{Controller=Home}/{Action=Index}/{id?}");

                endpoints.MapControllerRoute(
                                             "default",
                                             "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}