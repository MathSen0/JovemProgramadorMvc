using JovemProgramadorMvc.Data.Repositório.Interfaces;
using JovemProgramadorMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc.Data.Repositório
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContexto _bancoContexto;
        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public AlunoModel Inserir(AlunoModel aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
            return aluno;
        }

        public List<AlunoModel> BuscarAlunos()
        {
            return _bancoContexto.Aluno.ToList();
        }
        public AlunoModel BuscarId(int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(x => x.Id == id);
        }

        public bool Atualizar(AlunoModel aluno)
        {
            AlunoModel AlunoDb = BuscarId(aluno.Id);

            if (AlunoDb == null)
                return false;

            AlunoDb.Nome = aluno.Nome;
            AlunoDb.Idade = aluno.Idade;
            AlunoDb.Contato = aluno.Contato;
            AlunoDb.Email = aluno.Email;
            AlunoDb.Cep = aluno.Cep;

            _bancoContexto.Aluno.Update(AlunoDb);
            _bancoContexto.SaveChanges();

            return true;
        }


        public bool Excluir(int Id)
        {
            AlunoModel aluno = BuscarId(Id);

            if (aluno == null)
                return false;

            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();

            return true;
        }

        public List<AlunoModel> FiltroMaiorIdade(int idade)
        {
            return _bancoContexto.Aluno.Where(x => x.Idade > idade).ToList();
        }

        public List<AlunoModel> FiltroigualIdade(int idade)
        {
            return _bancoContexto.Aluno.Where(x => x.Idade == idade).ToList();
        }

        public List<AlunoModel> FiltroMenorIdade(int idade)
        {
            return _bancoContexto.Aluno.Where(x => x.Idade < idade).ToList();
        }

        public List<AlunoModel> FiltroNome(string nome)
        {
            return _bancoContexto.Aluno.Where(x => x.Nome.Contains(nome)).ToList();
        }
        public List<AlunoModel> FiltroContato(string contato)
        {
            return _bancoContexto.Aluno.Where(x => x.Contato.Contains(contato)).ToList();
        }

    }
}
