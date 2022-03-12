using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc.Controllers
{
    public class AlunoController : Controller 
    {
        public AlunoController()
        {

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
        public IActionResult BuscarCep(string cep)
        {
            return View();
        }
    }
}
        