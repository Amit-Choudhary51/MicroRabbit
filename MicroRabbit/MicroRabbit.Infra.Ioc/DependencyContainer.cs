using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MicroRabbit.Infra.Ioc
{
    public static class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            // Domain Events
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Banking Application services
            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<IAccountRepository,AccountRepository>();

            //services.AddTransient<BankingDBContext>();
            
        }
    }
}
