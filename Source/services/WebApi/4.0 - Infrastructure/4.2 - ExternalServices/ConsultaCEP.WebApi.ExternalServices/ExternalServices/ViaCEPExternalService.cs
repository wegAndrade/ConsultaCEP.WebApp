using ConsultaCEP.WebApi.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsultaCEP.WebApi.ExternalServices.ExternalServices
{
    public class ViaCEPExternalService: IViaCEPExternalService
    {
        private readonly HttpClient _httpClient;

        public ViaCEPExternalService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");
        }


        public async Task<Endereco> ObterCEP(string cep)
        {
            var response = await _httpClient.GetAsync($"{cep}/json/");
            return await JsonSerializer.DeserializeAsync<Endereco>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
