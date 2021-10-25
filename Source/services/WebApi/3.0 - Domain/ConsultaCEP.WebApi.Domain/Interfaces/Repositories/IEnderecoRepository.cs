using ConsultaCEP.WebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCEP.WebApi.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task InserirEndereco(Endereco endereco);
        Task<Endereco> ObterEndereco(string cep);
    }
}
