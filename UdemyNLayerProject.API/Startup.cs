using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.API.ExtensionMethods;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWork;
using UdemyNLayerProject.Data;
using UdemyNLayerProject.Data.Repositories;
using UdemyNLayerProject.Data.UnitOfWork;
using UdemyNLayerProject.Service.Services;

namespace UdemyNLayerProject.API
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped (typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<NotFoundFilter>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
           
            services.AddTransient<IUnitOfWork, UnitOfWork>(); 

            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseSqlServer(Configuration["ConnectionString:SqlConStr"].ToString(), o =>
                {
                    o.MigrationsAssembly("UdemyNLayerProject.Data");
                });
            });


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
          
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
