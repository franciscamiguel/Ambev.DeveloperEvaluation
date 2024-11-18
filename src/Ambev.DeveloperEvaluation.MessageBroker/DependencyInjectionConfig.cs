using System.Diagnostics.CodeAnalysis;
using Ambev.DeveloperEvaluation.MessageBroker.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace Ambev.DeveloperEvaluation.MessageBroker;

[ExcludeFromCodeCoverage]
public static class DependencyInjectionConfig
{
    public static void ConfigureMessageBroker(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<QueueSettings>(configuration.GetSection(nameof(QueueSettings)));

        services.Configure<HealthCheckPublisherOptions>(options =>
        {
            options.Delay = TimeSpan.FromSeconds(2);
            options.Predicate = check => check.Tags.Contains("ready");
        });

        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            x.AddConsumer<SaleCreatedConsumer>(j =>
            {
                j.UseMessageRetry(r => r.Interval(3, TimeSpan.FromMilliseconds(3000)));
            });

            x.AddConsumer<SaleUpdatedConsumer>(j =>
            {
                j.UseMessageRetry(r => r.Interval(3, TimeSpan.FromMilliseconds(3000)));
            });

            x.AddConsumer<SaleCancelledConsumer>(j =>
            {
                j.UseMessageRetry(r => r.Interval(3, TimeSpan.FromMilliseconds(3000)));
            });
            
            x.AddConsumer<SaleItemCancelledConsumer>(j =>
            {
                j.UseMessageRetry(r => r.Interval(3, TimeSpan.FromMilliseconds(3000)));
            });

            x.AddConsumer<SaleDeletedConsumer>(j =>
            {
                j.UseMessageRetry(r => r.Interval(3, TimeSpan.FromMilliseconds(3000)));
            });

            x.UsingRabbitMq((context, cfg) =>
            {
                var queueSettings = context.GetRequiredService<IOptions<QueueSettings>>().Value;

                cfg.Host(queueSettings.Address, queueSettings.VirtualHost, h =>
                {
                    h.Username(queueSettings.Username);
                    h.Password(queueSettings.Password);
                });
                
                cfg.ConfigureJsonSerializerOptions(options =>
                {
                    options.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                    options.PropertyNameCaseInsensitive = true;

                    return options;
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    }
}