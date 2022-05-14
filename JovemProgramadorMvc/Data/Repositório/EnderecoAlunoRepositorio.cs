using JovemProgramadorMvc.Data.Repositório.Interfaces;
using JovemProgramadorMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc.Data.Repositório
{
    public class EnderecoAlunoRepositorio : IEnderecoRepositorio
    {
        private readonly BancoContexto _bancoContexto;
        public EnderecoAlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public EnderecoModel InserirEndereco(EnderecoModel endereco)
        {
            _bancoContexto.EnderecoAluno.Add(endereco);
            _bancoContexto.SaveChanges();
            return endereco;
        }
    }
}