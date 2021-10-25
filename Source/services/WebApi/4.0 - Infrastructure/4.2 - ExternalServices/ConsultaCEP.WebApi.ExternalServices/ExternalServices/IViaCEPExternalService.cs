using ConsultaCEP.WebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCEP.WebApi.ExternalServices.ExternalServices
{
    public interface IViaCEPExternalService
    {
        Task<Endereco> ObterCEP(string cep);
    }
}
