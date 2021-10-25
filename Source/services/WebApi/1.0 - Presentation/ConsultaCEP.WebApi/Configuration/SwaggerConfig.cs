using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCEP.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.GetCustomAttributes(false).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? x.Name);

                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "API Endereço",
                    Description = "API responsável por Buscar Enderecos através do CEP e salva-los"
                });


            });

            return services;
        }
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/Enderecos/swagger/{documentname}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Enderecos";
                c.SwaggerEndpoint("/api/Enderecos/swagger/v1/swagger.json", "API Endereço");
                c.RoutePrefix = "api/Enderecos/swagger";
            });

            return app;
        }
    }
}
