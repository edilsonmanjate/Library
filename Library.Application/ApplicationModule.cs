using FluentValidation;

using Library.Application.Common.Behavior;
using Library.Application.Features.Users.Commands.CreateUser;



using MediatR;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Library.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(ApplicationModule))
                .AddMediator()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
                .AddSingleton(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            ;

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly); });

            return services;
        }
    }
}
