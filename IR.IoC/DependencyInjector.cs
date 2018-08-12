using IR.Command;
using IR.Command.Notifications;
using IR.Data.EFCore.Context;
using IR.Data.EFCore.Repositories;
using IR.Data.EFCore.UoW;
using IR.Domain.Interface;
using IR.Service.Classes;
using IR.Service.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IR.IoC
{
    public class DependencyInjector
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IRContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IContribuinteService, ContribuinteService>();

            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();

            services.AddScoped<IRequestHandler<IncluirContribuinteCommand>, IncluirContribuinteHandler>();

            services.AddScoped<IContribuinteRepository, ContribuinteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRContext>();

        }
    }
}
