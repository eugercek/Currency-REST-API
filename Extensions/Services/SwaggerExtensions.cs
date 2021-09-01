using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.Services
{
    public static partial class ConfigureExtensions
    {
        public static void SwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1.0";
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
        }
    }
}