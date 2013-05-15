using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2do.Models;

namespace _2do.Tests
{
    [TestClass]
    public class TarefaTest
    {
        [TestMethod]
        public void ConsigoConcluirTarefa()
        {
            var tarefa = new Tarefa {Descricao = "Teste"};

            Assert.IsNull(tarefa.DataFinalizacao);

            tarefa.ConcluirTarefa();

            Assert.IsNotNull(tarefa.DataFinalizacao);

        }
    }
}
