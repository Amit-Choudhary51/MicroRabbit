using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MicroRabbit.Infra.Ioc
{
    public static class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            // Event Bus 
            //services.AddTransient<IEventBus, RabbitMQBus>();

            // Event Bus using service scope Factory
            services.AddTransient<IEventBus, RabbitMQBus>(sp =>
            {
               var serviceFactory= sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), serviceFactory);
            });

            // Subscription
            services.AddTransient<TransferEventHandler>();

            //Domain Event
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //  Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand,bool>, TransferCommandHandler>();


            // Banking Application services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            // Data
            services.AddTransient<IAccountRepository,AccountRepository>();
            services.AddTransient<ITransferLogRepository, TransferLogRepository>();

            services.AddTransient<BankingDBContext>();
            services.AddTransient<TransferDBContext>();

        }
    }
}
