using ConsultaCEP.WebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCEP.WebApi.Domain.Interfaces.Services
{
    public interface IServiceEndereco
    {
        Task InserirEndereco(Endereco endereco);
        Task<Endereco> ObterEndereco(string cep);
    }
}
