using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Order.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMassTransit(busRegistrationConfigurator =>
            {
                // Transport (many more transport over there: RabbitMQ, Amazon Bus Service, Amazon SQS, ActiveMQ, Kafka etc)
                // This callback inside UsingRabbitMq, invoked after the service collection has been built.
                busRegistrationConfigurator.UsingRabbitMq((busRegistrationContext, rabbitMqBusFactoryConfigurator) =>
                {
                    rabbitMqBusFactoryConfigurator.Host("localhost", "", rabbitMqHostSettings =>
                    {
                    });
                });
            });

            return services;
        }
    }
}
