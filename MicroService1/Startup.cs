using System;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared;

namespace MicroService1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureMassTransit(services);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        public void ConfigureMassTransit(IServiceCollection services)
        {
            var busConfig = new BusConfig();
            Configuration.GetSection("BusConfig").Bind(busConfig);

            services.AddMassTransit(x =>
            {
                x.AddConsumer<MainConsumerSrv1>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri(busConfig.Host), h =>
                    {
                        h.Username(busConfig.Username);
                        h.Password(busConfig.Password);
                    });

                    cfg.ReceiveEndpoint(host, "request-service-1-queue", ep =>
                    {
                        ep.ConfigureConsumer<MainConsumerSrv1>(provider);

                    });
                }));
            });

            EndpointConvention.Map<GatewayCommand>(new Uri("rabbitmq://localhost/request-service-main-queue"));
            EndpointConvention.Map<Service2Command>(new Uri("rabbitmq://localhost/request-service-2-queue"));

            services.AddSingleton<IHostedService, MassTransitHostedService>();

        }
    }
}
