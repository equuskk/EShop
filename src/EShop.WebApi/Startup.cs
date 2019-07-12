using System.Reflection;
using EShop.Application.Products.Queries.GetAllProducts;
using EShop.DataAccess;
using EShop.Domain.Entities;
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

            services.AddIdentity<ShopUser, IdentityRole>() // TODO: settings
                    .AddEntityFrameworkStores<UsersDbContext>()
                    .AddDefaultTokenProviders();


            services.AddMediatR(typeof(GetAllProductsQuery).GetTypeInfo().Assembly);

            services.AddSwaggerDocument();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}