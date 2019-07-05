using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDbLibrary.DataAccess;
using MongoDbLibrary.DataAccess.EntityFramework;
using NewsBusiness.Concrete;
using NewsCore.Abstract;
using NewsDataRepository.Concrete.EntityFramework;
using NewsDataRepository.Interfaces;
using NewsDataRepositoryNewsDataRepository.Concrete.EntityFramework;
using NewsEntities.Entities;

namespace NewsPanel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

            public Startup(IHostingEnvironment env)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                ConfigurationBuilder = builder.Build();
            }
        public IConfigurationRoot ConfigurationBuilder { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseMongoRepository<>), typeof(BaseMongoRepository<>));
            services.AddScoped<INewsRepository, NewsGatewayRepository>();

            string mongoConnectionString = this.Configuration.GetConnectionString("MongoConnectionString");

            // services.AddTransient<News>();
            services.AddScoped<INewsService, NewsService>();
           // services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            //services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
            //services.AddSingleton<IDatabaseSettings>(sp =>
            //sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);


            services.AddDbContext<NContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=news}/{action=Index}/{id?}");
            });
        }
    }
}
