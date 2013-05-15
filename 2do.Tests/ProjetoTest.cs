using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2do.Models;

namespace _2do.Tests
{
    [TestClass]
    public class ProjetoTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),AllowDerivedTypes = true)]
        public void NaoConsigoCriarProjetoComDataInicioAnteriorADataAtual()
        {
            var projeto = ProjetoUtil.NovoProjetoComTarefas();

            projeto.DataInicio = DateTime.Now.AddYears(-1);

            Assert.IsNotNull(projeto);
            Assert.IsNotNull(projeto.DataInicio);
        }
    }

    public static class ProjetoUtil
    {
        public static Projeto NovoProjetoComTarefas()
        {

            var tarefas = new List<Tarefa>
                {
                    new Tarefa {Descricao = "Tarefa Teste1"},
                    new Tarefa() {Descricao = "Tarefa Teste2"}
                };

            var projeto = new Projeto { Nome = "Projeto Teste" };
            projeto.AdicionarTarefa(tarefas);

            return projeto;

        }
    }
}
