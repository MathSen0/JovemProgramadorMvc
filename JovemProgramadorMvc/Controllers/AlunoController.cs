﻿using JovemProgramadorMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JovemProgramadorMvc.Controllers
{
    public class AlunoController : Controller 
    {
        private readonly IConfiguration _configuration;
        
        
        public AlunoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Mensagem()
        {
            return View();
        }
        public async Task<IActionResult> BuscarCep(string cep)
        {
            EnderecoModel enderecoModel = new();

            try
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");
                if(result.IsSuccessStatusCode)
                {
                    enderecoModel = JsonSerializer.Deserialize<EnderecoModel> (
                        await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });
                }
            }
            catch (Exception e)
            {

            }
            
            return View("Buscarcep", enderecoModel);
        }
    }
}
        