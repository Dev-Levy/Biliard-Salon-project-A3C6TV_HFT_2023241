using A3C6TV_HFT_2023241.Logic;
using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace A3C6TV_HFT_2023241.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TajfunDBContext>();

            services.AddTransient<IRepository<Booking>, BookingRepository>();
            services.AddTransient<IRepository<Customer>, CustomerRepository>();
            services.AddTransient<IRepository<PoolTable>, PoolTableRepository>();

            services.AddTransient<IBookingLogic, BookingLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<IPoolTableLogic, PoolTableLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "A3C6TV_HFT_2023241.Endpoint", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "A3C6TV_HFT_2023241.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                .Get<IExceptionHandlerPathFeature>()
                .Error;
                var response = new { msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
