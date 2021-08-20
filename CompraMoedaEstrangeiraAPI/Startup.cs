using CompraMoedaEstrangeira.Data;
using CompraMoedaEstrangeira.Service;
using CompraMoedaEstrangeiraAPI.Filters;
using ExchangeRates;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace CompraMoedaEstrangeiraAPI
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

            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ICalculadoraService, CalculadoraService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ISegmentoClienteService, SegmentoClienteService>();
            services.AddSingleton<ISegmentoRepository, SegmentoRepository>();
            services.AddTransient<IExchangeRate, FakeExchangeRate>();
            services.AddTransient<ICalculadoraTaxaSegmento, CalculadoraTaxaSegmento>();

            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Calculadora de Moeda Estrangeira",
                    Version = "v1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseHttpsRedirection();

            app.UseGlobalExceptionHandler();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = string.Empty;
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

                });
        }
    }
}
