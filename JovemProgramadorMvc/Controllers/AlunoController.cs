using JovemProgramadorMvc.Data.Repositório.Interfaces;
using JovemProgramadorMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace JovemProgramadorMvc.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunorepositorio;

        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunorepositorio = alunoRepositorio;
        }
        public IActionResult Index(AlunoModel FiltroAluno)
        {
            List<AlunoModel> aluno = new();

                aluno = _alunorepositorio.BuscarAlunos();

            if (FiltroAluno.Idade > 0)
            {
               aluno = _alunorepositorio.FiltroIdade(FiltroAluno.Idade, FiltroAluno.Operacao);
            }
            if (FiltroAluno.Nome != null)
            {
                aluno = _alunorepositorio.FiltroNome(FiltroAluno.Nome);
            }
            if(FiltroAluno.Contato != null)
            {
                aluno = _alunorepositorio.FiltroContato(FiltroAluno.Contato);
            }
            return View(aluno);

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
                if (result.IsSuccessStatusCode)
                {
                    enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(
                        await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });

                    if (enderecoModel.Complemento == "")
                    {
                        enderecoModel.Complemento = "Sem complemento";
                    }

                    if (Regex.IsMatch(cep, (@"000")) == true)
                    {
                        enderecoModel.Logradouro = "CEP geral de " + enderecoModel.Localidade;
                        enderecoModel.Bairro = "Não especificado";
                    }
                }
                else
                {

                    ViewData["Mensagem"] = " Erro na busca do endereço!";
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                _ = ViewData["Mensagem"] + "Erro" + e + "na requisição";
            }

            return View("Buscarcep", enderecoModel);
        }

        public IActionResult Inserir(AlunoModel aluno)
        {
            var retorno = _alunorepositorio.Inserir(aluno);
            if (retorno != null)
            {
                TempData["Mensagem2"] = "Dados gravados com sucesso!";
            }
            return RedirectToAction("index");
        }
        public IActionResult Editar(int id)
        {
            var aluno = _alunorepositorio.BuscarId(id);
            return View("Editar", aluno);
        }
        public IActionResult Atualizar(AlunoModel aluno)
        {

            var retorno = _alunorepositorio.Atualizar(aluno);
            if (retorno == true)
                TempData["Mensagem4"] = "Dados alterados com sucesso";
            else
                TempData["Mensagem4"] = "Não foi possivel alterar os dados do aluno!";

            return RedirectToAction("Index");
        }
        public IActionResult Excluir(int Id)
        {
            var retorno = _alunorepositorio.Excluir(Id);
            if (retorno != false)
                TempData["Mensagem3"] = "Aluno excluido com sucesso!";
            else
                TempData["Mensagem3"] = "Não foi possivel excluir o aluno";

            return RedirectToAction("Index");
        }
    }
}
