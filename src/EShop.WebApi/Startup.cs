using System.Reflection;
using EShop.Application.Products.Queries.GetProducts;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.WebApi.Extensions;
using EShop.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProductsDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(connectionString));

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
                    .AddEntityFrameworkStores<UsersDbContext>()
                    .AddDefaultTokenProviders();

            services.AddJwtAuth(Configuration);

            services.AddMediatR(typeof(GetProductsQuery).GetTypeInfo().Assembly);

            services.AddSwaggerDocument(x =>
            {
                x.Title = "EShop API v1";
            });

            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                app.UseOpenApi();
                app.UseSwaggerUi3(settings => { settings.Path = "/api"; });
            }
            else
            {
                app.UseHsts();
            }
			
			app.UseCors(builder => builder 
						.AllowAnyOrigin() 
						.AllowAnyMethod() 
						.AllowAnyHeader() 
						.AllowCredentials());

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}