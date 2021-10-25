using ConsultaCEP.WebApi.Application.Interfaces;
using ConsultaCEP.WebApi.Domain.Interfaces.Services;
using ConsultaCEP.WebApi.Domain.Models;
using ConsultaCEP.WebApi.ExternalServices.ExternalServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsultaCEP.WebApi.Application.Application
{
    public class EnderecoApp: IEnderecoApp
    {
        private readonly IViaCEPExternalService _viaCEPExternalService;
        private readonly IServiceEndereco _serviceEndereco;

        public EnderecoApp(IViaCEPExternalService viaCEPExternalService, IServiceEndereco serviceEndereco)
        {
            _viaCEPExternalService = viaCEPExternalService;
            _serviceEndereco = serviceEndereco;
        }

        public async Task Inserir(Endereco endereco)
        {
            endereco.CEP = this.FormataCEP(endereco.CEP);
            await _serviceEndereco.InserirEndereco(endereco);
        }

        public async Task<Endereco> ObterEnderecoDB(string cep)
        {
            return await _serviceEndereco.ObterEndereco(FormataCEP(cep));
        }

        public async Task<Endereco> ObterEnderecoWS(string cep)
        {
            return await _viaCEPExternalService.ObterCEP(FormataCEP(cep));
        }

        private string FormataCEP(string cep)
        {
            cep =  Regex.Replace(cep, "^[A-Z]+$", "");
            return  Regex.Replace(cep, @"[^\d]","");
        }
        public bool ValidaCEP(string cep)
        {
            Regex Rgx = new Regex(@"^\d{5}\d{3}$");

            if (!Rgx.IsMatch(cep))
                return false;
            else
                return true;
        }
    }
}
