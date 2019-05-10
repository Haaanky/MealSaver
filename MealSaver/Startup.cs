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
using System.Globalization;

namespace MealSaver
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var connStringIdentity = configuration.GetConnectionString("defaultConnection"); // not safe, stored in appsettings.json
            //var connString = configuration["defaultConnection"]; // safer, stored in user secrets, will later be stored in azure server secrets
            var connString = configuration.GetConnectionString("defaultConnection");

            // Identity/User stuff below
            services.AddDbContext<MyIdentityContext>(o => o.UseSqlServer(connString));
            services.AddIdentity<MyIdentityUser, IdentityRole>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6; // change to longer requirement before live
            })
            .AddEntityFrameworkStores<MyIdentityContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(o => o.LoginPath = "/logga-in"); // välja vart login ska vara

            // FoodObj database schema below 
            services.AddDbContext<FoodObjContext>(o => o.UseSqlServer(connString));

            // General purpose stuff below
            services.AddTransient<UserService>(); // lägg till de services vi kommer behöva ha flera instanser av
            services.AddTransient<InfoService>();
            services.AddTransient<ItemService>();

            services.AddMvc(o =>
            {
                //if (env.IsProduction())
                //{
                //    o.Filters.Add(new RequireHttpsAttribute());
                //}
            });
            services.AddHttpsRedirection(o =>
            {
                //o.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                //o.HttpsPort = 5001;

            });
            services.AddSession();
            services.AddMemoryCache();

            // Cookies
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Kulturinställningar
            var cultureInfo = new CultureInfo("sv-SE");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error/servererror");
                app.UseHsts();
            }
            app.UseStatusCodePagesWithRedirects("/error/httpError/{0}");
            app.UseCookiePolicy();

            app.UseSession();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
        }
    }
}
