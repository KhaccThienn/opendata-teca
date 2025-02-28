namespace Application
{
    /// <summary>
    /// Lớp DependencyInjections cung cấp các phương thức mở rộng để đăng ký các dịch vụ ứng dụng.
    /// </summary>
    public static class DependencyInjections
    {
        /// <summary>
        /// Đăng ký các dịch vụ ứng dụng vào IServiceCollection.
        /// </summary>
        /// <param name="services">IServiceCollection để đăng ký các dịch vụ.</param>
        /// <returns>IServiceCollection với các dịch vụ đã được đăng ký.</returns>
        public static IServiceCollection AddApplicationServicesExtension(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(executingAssembly);

            services.AddValidatorsFromAssembly(executingAssembly);

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(executingAssembly);

                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            return services;
        }
    }
}
