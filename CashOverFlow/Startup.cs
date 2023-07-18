//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using CashOverFlow.Brokers.DateTimes;
using CashOverFlow.Brokers.Loggings;
using CashOverFlow.Brokers.Storages;
using CashOverFlow.Services.Foundations.Languages;
using CashOverFlow.Services.Foundations.Locations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CashOverFlow
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var operApiInfo = new OpenApiInfo
            {
                Title = "CashOverFlow",
                Version = "v1"
            };

            services.AddControllers();
            AddBrokers(services);
            AddServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    name: "v1",
                    info: operApiInfo);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment enviroment)
        {
            if (enviroment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(option =>
                    option.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json",
                        name: "CashOverFlow v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }
        private static void AddBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ILanguageService, LanguageService>();
        }
    }
}
