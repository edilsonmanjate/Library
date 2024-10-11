using Library.Application.Features.Users.Commands.CreateUser;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(ApplicationModule))
                .AddMediator();

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly); });

            return services;
        }
    }
}
