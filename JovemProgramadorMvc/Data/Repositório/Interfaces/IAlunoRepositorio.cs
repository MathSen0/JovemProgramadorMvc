﻿using JovemProgramadorMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc.Data.Repositório.Interfaces
{
    public interface IAlunoRepositorio
    {
        AlunoModel Inserir(AlunoModel aluno);

        List<AlunoModel> BuscarAlunos();

        AlunoModel BuscarId(int Id);

        bool Atualizar(AlunoModel aluno);

        bool Excluir(int Id);

        List<AlunoModel> FiltroMaiorIdade(int idade);

        List<AlunoModel> FiltroigualIdade(int idade);

        List<AlunoModel> FiltroMenorIdade(int idade);

        List<AlunoModel> FiltroNome(string nome);

        List<AlunoModel> FiltroContato(string contato);
    }
}
