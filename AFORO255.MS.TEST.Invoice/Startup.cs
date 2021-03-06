using AFORO255.MS.TEST.Invoice.RabbitMQ.EventHandlers;
using AFORO255.MS.TEST.Invoice.RabbitMQ.Events;
using AFORO255.MS.TEST.Invoice.Repository;
using AFORO255.MS.TEST.Invoice.Repository.Data;
using AFORO255.MS.TEST.Invoice.Service;
using Consul;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.AFORO255.Cross.Consul.Consul;
using MS.AFORO255.Cross.Consul.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;

namespace AFORO255.MS.TEST.Invoice
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
            services.AddControllers();

            services.AddDbContext<ContextDatabase>(
               opt =>
               {
                   //opt.UseNpgsql(Configuration["postgres:cn"]);
                   opt.UseNpgsql(Configuration["cnpostgres"]);
               });

            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<IContextDatabase, ContextDatabase>();

            /*Start - RabbitMQ*/
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();

            services.AddTransient<PayEventHandler>();
            services.AddTransient<IEventHandler<PayCreatedEvent>, PayEventHandler>();
            /*End - RabbitMQ*/

            /*Start - Consul*/
            services.AddSingleton<IServiceId, ServiceId>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddConsul();
            /*End - Consul*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime hostApplicationLifetime, IConsulClient consulClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);


            var serviceId = app.UseConsul();
            hostApplicationLifetime.ApplicationStopped.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(serviceId);
            });
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<PayCreatedEvent, PayEventHandler>();
        }
    }
}
