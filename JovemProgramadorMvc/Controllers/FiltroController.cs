using JovemProgramadorMvc.Data.Repositório;
using JovemProgramadorMvc.Data.Repositório.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JovemProgramadorMvc.Models;

namespace JovemProgramadorMvc.Controllers
{
    public class FiltroController: Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunorepositorio;

        public FiltroController()
        {

        }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult FiltroIdade(int idade)
        {
                var Idade = _alunorepositorio.FiltroIdade(idade);
                return RedirectToAction("Index");
        }
    }
}
