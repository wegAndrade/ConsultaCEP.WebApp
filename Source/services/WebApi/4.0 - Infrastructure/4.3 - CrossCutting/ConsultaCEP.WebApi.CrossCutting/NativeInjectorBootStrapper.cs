using ConsultaCEP.WebApi.Application.Application;
using ConsultaCEP.WebApi.Application.Interfaces;
using ConsultaCEP.WebApi.Data.Repositories;
using ConsultaCEP.WebApi.Domain.Interfaces.Repositories;
using ConsultaCEP.WebApi.Domain.Interfaces.Services;
using ConsultaCEP.WebApi.Domain.Services;
using ConsultaCEP.WebApi.ExternalServices.ExternalServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsultaCEP.WebApi.CrossCutting
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IServiceEndereco, ServiceEndereco>();
            services.AddScoped<IViaCEPExternalService, ViaCEPExternalService>();
            services.AddScoped<IEnderecoApp, EnderecoApp>();
        }
    }
}
