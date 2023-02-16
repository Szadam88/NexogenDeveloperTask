namespace LoggerLibrary.Extensions
{
    using LoggerLibrary._Abstraction;
    using LoggerLibrary.Factory;
    using Microsoft.Extensions.DependencyInjection;

    public static class LoggerLibraryExtensions
    {
        public static IServiceCollection AddLoggerServices(this IServiceCollection services)
        {
            services.AddScoped<ILoggerFactory, LoggerFactory>();
            return services;
        }
    }
}