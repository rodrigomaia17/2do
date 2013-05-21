using System;
using System.Collections.Generic;
using System.Linq;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Data.Local
{
    internal class LocalProjetoRepository : LocalCrudRepository<Projeto>, IProjetoRepository
    {
        public LocalProjetoRepository()
        {

            var colaborador = new LocalColaboradorRepository().GetAll().First();

            var list = new List<Tarefa>
                {
                    new Tarefa() {Descricao = "Descricao Teste"},
                    new Tarefa() {Descricao = "Descricao Teste 2"}
                };

            var projeto = new Projeto() { Nome = "ProjetoTeste" };


            foreach (var tarefa in list)
            {
                tarefa.AdicionarColaborador(colaborador);
                projeto.Tarefas.Add(tarefa);
            }

            projeto.AdicionarColaborador(colaborador);
            Insert(projeto);
        }
    }
}