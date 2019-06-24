using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository;
using Belatrix.Exam.WebApi.Repository.MySql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Belatrix.Exam.WebApi
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
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile<CustomerProfile>();
            //});
            
            //services.AddAutoMapper(typeof(CustomerProfile).Assembly);

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddEntityFrameworkNpgsql()
               .AddDbContextPool<ChinookDbContext>(
                opt => opt.UseNpgsql(Configuration.GetConnectionString("postgresql"),
                b => b.MigrationsAssembly("Belatrix.Exam.WebApi")))
               .BuildServiceProvider();

            services.AddTransient<IRepository<Album>, Repository<Album>>();
            services.AddTransient<IRepository<Customer>, Repository<Customer>>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Belatrix Exam API",
                    Version = "v1"
                });
                c.CustomSchemaIds(x => x.FullName);
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Belatrix Exam Api v1");
            });
        }
    }
}
