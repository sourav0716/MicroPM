using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProjectService.Application.Common.Interfaces;
using ProjectService.Infrastructure.Services;

namespace ProjectService.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IComponentService, ComponentService>();
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<IProjectService, ProjectServices>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserGroupService, UserGroupService>();
        services.AddTransient<IWorkflowService,WorkflowService>();  

        return services;
    }
}