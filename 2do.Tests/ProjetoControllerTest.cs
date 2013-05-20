using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcContrib.TestHelper;
using System.Web.Mvc;
using System.Web.Routing;
using _2do.Controllers;
using _2do.Data.Factory;
using _2do.Data.Interfaces;
using _2do.Models;
using _2do.ViewModels;


namespace _2do.Tests
{
    [TestClass]
    public class ProjetoControllerTest
    {
        private static ProjetoController _controller;
        private static Mock<IProjetoRepository> _repo;
        private static Mock<IRepositoryFactory> _factory;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            _repo = new Mock<IProjetoRepository>();
            _factory = new Mock<IRepositoryFactory>();
            _factory.Setup(f => f.getProjetoRepository()).Returns(_repo.Object);
            _controller = new ProjetoController(_factory.Object);

        }


        [TestMethod]
        public void ProjetoIndexDeveSerPaginaPrincipal()
        {
            "~/".ShouldMapTo<ProjetoController>(action => action.Index());
        }

        [TestMethod]
        public void IndexActionDeveRetornarListaProjetos()
        {
            _repo.Setup(p => p.GetAll()).Returns(new List<Projeto> { ProjetoUtil.NovoProjetoComTarefas(), ProjetoUtil.NovoProjetoComTarefas() }.AsQueryable);

            var result = _controller.Index();

            result.AssertViewRendered().ViewName.Equals("Index");
            _repo.Verify(r => r.GetAll());
            result.AssertViewRendered().WithViewData<IEnumerable<ProjetoListViewModel>>();
        }
    }
}
