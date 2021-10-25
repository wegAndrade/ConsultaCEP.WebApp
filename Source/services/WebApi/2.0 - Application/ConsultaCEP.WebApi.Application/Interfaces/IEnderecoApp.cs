using ConsultaCEP.WebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCEP.WebApi.Application.Interfaces
{
    public interface IEnderecoApp
    {
        Task<Endereco> ObterEnderecoWS(string cep);
        Task<Endereco> ObterEnderecoDB(string cep);
        Task Inserir(Endereco endereco);
        bool ValidaCEP(string cep);
    }
}
