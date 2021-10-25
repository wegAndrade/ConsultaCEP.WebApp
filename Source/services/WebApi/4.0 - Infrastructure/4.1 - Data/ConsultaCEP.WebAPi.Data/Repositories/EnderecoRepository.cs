using ConsultaCEP.WebApi.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using ConsultaCEP.WebApi.Domain.Interfaces.Repositories;
using Npgsql;

namespace ConsultaCEP.WebApi.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string connectionString;

        public EnderecoRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("postgresConnection");
        }

        public async Task InserirEndereco(Endereco endereco)
        {
            var sql = "Insert into Endereco (CEP,Logradouro,Complemento,Bairro,Localidade,UF,IBGE,GIA,DDD,SIAFI) VALUES (@CEP,@Logradouro,@Complemento,@Bairro,@Localidade,@UF,@IBGE,@GIA,@DDD,@SIAFI)";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, endereco);
                connection.Close();
            }
        }

        public async Task<Endereco> ObterEndereco(string cep)
        {
            var sql = "SELECT * from Endereco WHERE CEP =:CEP";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Endereco>(sql, new { CEP = cep});
                return result.FirstOrDefault();
            }
        }
    }
}
