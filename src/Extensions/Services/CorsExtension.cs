using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.Services
{
    public static partial class ConfigureExtensions
    {
        public static void CorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "Policy",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                               .WithMethods("GET")
                               .AllowAnyOrigin();
                    });
            });
        }
    }
}