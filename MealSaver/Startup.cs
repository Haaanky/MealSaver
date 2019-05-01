using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MealSaver.Models;
using Microsoft.Extensions.Configuration;
using MealSaver.Models.Entities;

namespace MealSaver
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var connStringIdentity = configuration.GetConnectionString("defaultConnection");
            var connStringIdentity = configuration["defaultConnection"];
            //var connStringFoodObj = configuration.GetConnectionString("FoodObjSchema");
            //var mySecret = configuration["defaultConnection"];

            // Identity/User stuff below
            services.AddDbContext<MyIdentityContext>(o => o.UseSqlServer(connStringIdentity));
            services.AddIdentity<MyIdentityUser, IdentityRole>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<MyIdentityContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(o => o.LoginPath = "/logga-in"); // välja vart login ska vara


            // FoodObj database schema below 
            //services.AddDbContext<FoodObjContext>(o => o.UseSqlServer(connStringFoodObj));

            // General purpose stuff below
            services.AddTransient<UserService>(); // lägg till de services vi kommer behöva ha flera instanser av
            services.AddTransient<InfoService>();
            services.AddTransient<ItemService>();

            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }
    }
}
