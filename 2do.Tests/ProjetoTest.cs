using System;
using System.Collections.Generic;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2do.Models;

namespace _2do.Tests
{
    [TestClass]
    public class ProjetoTest
    {
        ProjetoValidator _validator = new ProjetoValidator();

        [TestMethod]
        [ExpectedException(typeof(Exception),AllowDerivedTypes = true)]
        public void NaoConsigoCriarProjetoComDataInicioAnteriorADataAtual()
        {
            var projeto = ProjetoUtil.NovoProjetoComTarefas();

            projeto.DataInicio = DateTime.Now.AddYears(-1);
            
            Assert.IsNotNull(projeto);
            Assert.IsNotNull(projeto.DataInicio);
            _validator.ValidateAndThrow(projeto);
        }
    }

    public static class ProjetoUtil
    {
        public static Projeto NovoProjetoComTarefas()
        {

            var tarefas = TarefaUtil.ListaNovasTarefas(2);

            var projeto = new Projeto { Nome = "Projeto Teste" };

            foreach (var tarefa in tarefas)
            {
                projeto.Tarefas.Add(tarefa);
            }
            

            return projeto;

        }
    }
}
