using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2do.Models;

namespace _2do.Tests
{
    [TestClass]
    public class TarefaTest
    {
        private readonly TarefaValidator _validator = new TarefaValidator();

        [TestMethod]
        public void ConsigoConcluirTarefa()
        {
            var tarefa = new Tarefa {Descricao = "Teste"};

            Assert.IsNull(tarefa.DataFinalizacao);

            tarefa.ConcluirTarefa();

            Assert.IsNotNull(tarefa.DataFinalizacao);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void TarefaSemResponsavelDeveLancarExcecao()
        {
            var tarefa = TarefaUtil.ListaNovasTarefas(1).First();
            
            
            _validator.ValidateAndThrow(tarefa);
        }
    }

    public static class TarefaUtil
    {
        public static IEnumerable<Tarefa> ListaNovasTarefas(int numTarefas)
        {
            var tarefas = new List<Tarefa>();

            for (var i = 0; i < numTarefas; i++)
            {
                tarefas.Add(new Tarefa {Descricao = "Tarefa Teste1"+i});
            }
            
            return tarefas;
        }
    }
}
