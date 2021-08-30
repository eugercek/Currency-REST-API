using System;
using API.Models;
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

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "Policy",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowAnyOrigin();
                    });
            });
            services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            }).AddXmlSerializerFormatters();

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Daily Currency Rates API";
                    document.Info.Description = "Parsed from https://www.tcmb.gov.tr/kurlar/today.xml";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Emin Umut Gerçek",
                        Email = "umutgercek1999@gmail.com",
                        Url = "umutgercek.net"
                    };
                };
            });


            services.AddDbContext<CurrencyContext>(
                 options => options.UseSqlite(Configuration.GetConnectionString("SQLite")));
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
            app.UseCors("MyPolicy");

        }
    }
}
