using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using WebApplication.Models;
using WebApplication.Services;

namespace Items
{
    public class Startup
    {
        private const string CorsAllowSpecificOrigins = "_corsAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<DataContext>(options =>
                    options
                    .UseNpgsql(Configuration.GetConnectionString("MainDbConnStr"))
            );
            services.AddScoped<IProductService, ProductService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsAllowSpecificOrigins, builder =>
                {
                    builder
                       .WithOrigins(
                             "http://localhost:8081"
                           )
                       .AllowCredentials()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       ;
                });
            });

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Swagger Items API",
                        Description = "Items API for showing Swagger",
                        Version = "v1"
                    });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors(CorsAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Items API");
                options.RoutePrefix = "";
            });
        }
    }
}
