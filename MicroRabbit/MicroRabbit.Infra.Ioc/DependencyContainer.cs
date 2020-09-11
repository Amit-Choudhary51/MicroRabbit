using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MicroRabbit.Infra.Ioc
{
    public static class DependencyContainer
    {
        public static void RegisterDepedency(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
