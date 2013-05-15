using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2do.Data;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Tests
{
    [TestClass]
    public class MongoDbRepositoryTest
    {
        private static IList<Guid> _listaExclusao;
        private static IProjetoRepository _projetoRepository;

        
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _listaExclusao = new List<Guid>();
            _projetoRepository = new MongoDbProjetoRepository();
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            foreach (var guid in _listaExclusao)
            {
                _projetoRepository.Delete(guid);
            }
        }
        

        [TestMethod]
        public void ConsigoCriarInstanciaDatabase()
        {
            var database = MongoDbHelper.GetDatabase();

            Assert.IsNotNull(database);
        }

        

        [TestMethod]
        public void ConsigoSalvarERecuperarProjetoComTarefas()
        {
            var projeto = ProjetoUtil.NovoProjetoComTarefas();

            _projetoRepository.Insert(projeto);

            Assert.IsTrue(projeto.Id != Guid.Empty);
            Assert.IsTrue(projeto.Tarefas.Any());

            var id = projeto.Id;

            var projetoRecuperado = _projetoRepository.GetById(id);

            Assert.IsTrue(projetoRecuperado.Tarefas.Any());
            Assert.IsTrue(!String.IsNullOrEmpty(projetoRecuperado.Nome));
            
        }

        [TestMethod]
        public void ConsigoExcluirProjeto()
        {
            var projeto = ProjetoUtil.NovoProjetoComTarefas();

            _projetoRepository.Insert(projeto);

            var id = projeto.Id;

            _projetoRepository.Delete(id);

            Assert.IsNull(_projetoRepository.GetById(id));
        }

        


    }
    
}
