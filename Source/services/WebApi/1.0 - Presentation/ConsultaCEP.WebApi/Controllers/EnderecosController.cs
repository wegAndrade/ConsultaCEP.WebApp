using ConsultaCEP.WebApi.Application.Interfaces;
using ConsultaCEP.WebApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaCEP.WebApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoApp _appService;

        public EnderecosController(IEnderecoApp appService)
        {
            _appService = appService;
            
        }
        [HttpPost("Incluir")]
        public async Task<IActionResult> Incluir(Endereco endereco)
        {
            
                await _appService.Inserir(endereco);

                return Ok();
            
        }
        [HttpGet("ObterWS/{cep}")]
        public async Task<IActionResult>ObterWS(string cep)
        {
            if (!_appService.ValidaCEP(cep))
                return BadRequest($"{cep} invalido");
            try
            {
                var result = await _appService.ObterEnderecoWS(cep);

                return Ok(result);
            }catch(Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }
        [HttpGet("ObterDB/{cep}")]
        public async Task<IActionResult> ObterDB(string cep)
        {
            if (!_appService.ValidaCEP(cep))
                return BadRequest($"{cep} invalido");
            try
            {
                var result = await _appService.ObterEnderecoDB(cep);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
