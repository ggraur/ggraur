using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.Json;
using Bakery.Data;
 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
 

namespace Bakery
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

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

            BakeryContext.isMigration = false;

            //var configuration = new Configuration().AddJsonFile("config.json");
            //services.AddEntityFramework(configuration)
            //    .AddSqlServer()
            //    .AddDbContext<MyDbContext>(config => config.UseSqlServer());

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddDbContext<BakeryContext>
                        (options => options
                        .UseSqlServer("Data Source=ggraur;Database=Bakery;User Id=sa;Password=260707Gruita;Trusted_Connection=True;MultipleActiveResultSets=true;")
                        //.AddInterceptors 
                        );
                        //.AddInterceptors(new MyInterceptor());
        }


        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json")
                            .Build();




            _env = env;
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


       

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

       
    }
}
