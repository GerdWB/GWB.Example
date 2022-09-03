// ReSharper disable UnusedMember.Global

namespace GWB.Example.Application.Core._DIRegistration;

using System.Reflection;
using Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddCommandsAndQueries(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandsValidationBehavior<,>));
        return services;
    }
}