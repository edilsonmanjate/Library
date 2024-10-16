using FluentValidation;
using FluentValidation.AspNetCore;

using Library.Application.Common.Behavior;
using Library.Application.Features.Books.Commands.CreateBookCommand;
using Library.Application.Features.Books.Commands.DeleteBookCommand;
using Library.Application.Features.Books.Commands.UpdateBookCommand;
using Library.Application.Features.Loans.Commands.CreateLoanCommand;
using Library.Application.Features.Loans.Commands.ReturnLoanCommand;
using Library.Application.Features.Loans.Commands.UpdateLoanCommand;
using Library.Application.Features.Users.Commands.CreateUserCommand;
using Library.Application.Features.Users.Commands.UpdateUserCommand;
using Library.Application.Features.Users.Queries.GetUserByIdQuery;

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
                //.AddAutoMapper(typeof(ApplicationModule))
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediator()
                .AddValidation()
                .AddServices();

            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
                .AddSingleton(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            return services;
        }
        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly); });

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddFluentValidationAutoValidation()

                .AddValidatorsFromAssemblyContaining<CreateBookCommand>()
                .AddValidatorsFromAssemblyContaining<UpdateBookCommand>()
                .AddValidatorsFromAssemblyContaining<DeleteBookCommand>()

                .AddValidatorsFromAssemblyContaining<CreateLoanCommand>()
                .AddValidatorsFromAssemblyContaining<UpdateLoanCommand>()
                .AddValidatorsFromAssemblyContaining<ReturnLoanCommand>()

                .AddValidatorsFromAssemblyContaining<CreateUserCommand>()
                .AddValidatorsFromAssemblyContaining<UpdateUserCommand>()

                .AddValidatorsFromAssemblyContaining<GetUserByIdQuery>()

                ;

            return services;
        }
    }
}
