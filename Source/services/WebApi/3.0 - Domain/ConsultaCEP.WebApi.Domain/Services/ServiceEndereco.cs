using ConsultaCEP.WebApi.Domain.Interfaces.Repositories;
using ConsultaCEP.WebApi.Domain.Interfaces.Services;
using ConsultaCEP.WebApi.Domain.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace ConsultaCEP.WebApi.Domain.Services
{
    public class ServiceEndereco : IServiceEndereco
    {
        private readonly IEnderecoRepository _enderecoRepository;
  
     

        public ServiceEndereco(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task InserirEndereco(Endereco endereco)
        {
            await _enderecoRepository.InserirEndereco(endereco);
        }

        public async Task<Endereco> ObterEndereco(string cep)
        {
            return await _enderecoRepository.ObterEndereco(cep);
        }

      
    }
}
