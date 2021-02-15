using GuauHouse.Data;
using GuauHouse.Helpers;
using GuauHouse.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse
{
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<PathProvider>();
            services.AddSingleton<UploadService>();
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme =
                        CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme =
                        CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme =
                        CookieAuthenticationDefaults.AuthenticationScheme;
                }).AddCookie();
            //services.AddAuthorization(
            //    options =>
            //    {
            //        options.AddPolicy("SoloUsuarios", policy => policy.RequireRole("2"));
            //    });
            services.AddTransient<IRepositoryGuauHouse, RepositoryGuauHouseSQL>();
            services.AddDbContext<GuauHouseContext>
                (options => options.UseSqlServer(this.Configuration.GetConnectionString("casasqlnaza")));
            services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default"
            //        , pattern: "{controller=Home}/{action=Index}/{id?}"
            //        );
            //});
        }
    }
}
