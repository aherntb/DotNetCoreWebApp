using System;
using DotNetCoreWebApp.HttpClients;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //services.AddHttpClient("gitHub", client =>
            // {
            //     client.BaseAddress = new Uri("https://api.github.com/");
            //     client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            //     client.DefaultRequestHeaders.Add("User-Agent", "my-user-agent");
            // });
            services.AddHttpClient<IGitHubHttpClient, GitHubHttpClient>();
            services.AddDbContext<AppDbContext>(options =>options.UseInMemoryDatabase("DB"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();


            
            
            app.UseMvc(routes =>
            {
                routes.MapRoute("API Default", "api/{controller}/{action=Index}/{id?}");
                routes.MapRoute("default", "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
