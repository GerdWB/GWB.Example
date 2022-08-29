namespace GWB.Example.Application.Core._DIRegistration;

using System.Reflection;
using Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddCommandsAndQueries(this IServiceCollection services)
    {
        //var mappings = from type in Assembly.GetExecutingAssembly().GetTypes()
        //    where !type.IsAbstract
        //    where !type.IsGenericType
        //    from i in type.GetInterfaces()
        //    where i.IsGenericType
        //    let gtd = i.GetGenericTypeDefinition()
        //    where gtd == typeof(ICommandHandler<>) || gtd == typeof(IQueryHandler<,>)
        //    select new { service = i, type };

        //foreach (var mapping in mappings)
        //{
        //    services.AddScoped(mapping.service, mapping.type);
        //}

        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandsValidationBehavior<,>));
        return services;
    }
}