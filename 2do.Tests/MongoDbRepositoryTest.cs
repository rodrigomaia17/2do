using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2do.Data;
using _2do.Data.Factory;
using _2do.Data.Interfaces;
using _2do.Data.MongoDb;
using _2do.Models;

namespace _2do.Tests
{
    
    [TestClass]
    public class MongoDbRepositoryTest
    {
        private static IList<Guid> _listaProjetosExclusao;
        private static IList<Guid> _listaColaboradoresExclusao;
        private static IProjetoRepository _projetoRepository;
        private static IColaboradorRepository _colaboradorRepository;

        
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            IRepositoryFactory factory = new MongoRepositoryFactory(); // No projeto eh instanciado via Injecao de Dependencia
            
            _listaProjetosExclusao = new List<Guid>();
            _listaColaboradoresExclusao = new List<Guid>();

            _projetoRepository = factory.getProjetoRepository();
            _colaboradorRepository = factory.getColaboradorRepository();

        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            foreach (var guid in _listaProjetosExclusao)
            {
                _projetoRepository.Delete(guid);
            }
            foreach (var guid in _listaColaboradoresExclusao)
            {
                _colaboradorRepository.Delete(guid);
            }
        }
        

      

        [TestMethod]
        public void ConsigoSalvarERecuperarProjetoComTarefasEColaborador()
        {
            var projeto = ProjetoUtil.NovoProjetoComTarefas();

            var colaborador = ColaboradorUtil.NovoColaborador();

            

            _colaboradorRepository.Insert(colaborador);
            Assert.IsTrue(colaborador.Id != Guid.Empty, "Nao foi possivel Salvar Colaborador");

            _listaColaboradoresExclusao.Add(colaborador.Id);

            projeto.AdicionarColaborador(colaborador);

            

            _projetoRepository.Insert(projeto);

            Assert.IsTrue(projeto.Id != Guid.Empty);
            _listaProjetosExclusao.Add(projeto.Id);
            Assert.IsTrue(projeto.Tarefas.Any());
            

            var id = projeto.Id;

            var projetoRecuperado = _projetoRepository.GetById(id);

            Assert.IsTrue(projetoRecuperado.Tarefas.Any());
            Assert.IsNotNull(projetoRecuperado.Responsavel);
            Assert.IsTrue(projetoRecuperado.Responsavel.Id != Guid.Empty);
            Assert.IsFalse(String.IsNullOrEmpty(projetoRecuperado.Nome));
            Assert.IsTrue(projeto.Tarefas.Any());
            
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
