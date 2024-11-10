using System.Reflection;

namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            //app.MapCarter();
            app.UseExceptionHandler(option => { });
            //app.UseHealthChecks("/health", new HealthCheckOptions
            //{
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});
            return app;
        }
    }
}
