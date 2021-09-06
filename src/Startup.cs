using System;
using API.Data.Contracts;
using API.Data.Models;
using API.Data.Repository;
using API.Extensions.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.CorsConfiguration();

            services.AddControllers(options => options.ReturnHttpNotAcceptable = true)
                .AddXmlSerializerFormatters();

            services.SwaggerConfiguration();

            services.AddDbContext<CurrencyContext>(options =>
            {
                // options.UseSqlite(Configuration.GetConnectionString("SQLite"));
                options.UseNpgsql(Configuration.GetConnectionString("Postgres"));
            });

            services.AddScoped<ICurrencyRepository, CurrencyRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseCors("Policy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
