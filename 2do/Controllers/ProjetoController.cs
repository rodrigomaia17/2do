using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Globalization;
using System.Web.Mvc;
using _2do.Data.Factory;
using _2do.Data.Interfaces;
using _2do.Models;
using _2do.ViewModels;
using FluentValidation;

namespace _2do.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IColaboradorRepository _colaboradorRepository;

        private readonly ProjetoValidator _validator = new ProjetoValidator();


        public ProjetoController(IRepositoryFactory repository)
        {
            _projetoRepository = repository.getProjetoRepository();
            _colaboradorRepository = repository.getColaboradorRepository();
        }

        //
        // GET: /Projeto/

        public ActionResult Index()
        {
            var projetos = from p in  _projetoRepository.GetAll() select new ProjetoListViewModel(p);
            return View(projetos);
        }

      
        //
        // GET: /Projeto/Create

        public ActionResult Create()
        {
            
            
            return View(new ProjetoFormViewModel(new Projeto(), _colaboradorRepository.GetAll()));
        }

        //
        // POST: /Projeto/Create

        [HttpPost]
        public ActionResult Create(ProjetoFormViewModel projetoVM)
        {
            
                var projeto = new Projeto();
                projetoVM.ToProjeto(projeto);

                projeto.AdicionarColaborador(_colaboradorRepository.GetById(projetoVM.ResponsavelId));

                _validator.ValidateAndThrow(projeto);

                _projetoRepository.Insert(projeto);

                return RedirectToAction("Index");
           
        }
        //
        // GET: /Projeto/CreateTarefa

        public ActionResult CreateTarefa(Guid idProjeto)
        {
            ViewBag.IdProjeto = idProjeto;
            return PartialView("CreateTarefa", new TarefaFormViewModel(new Tarefa(),idProjeto, _colaboradorRepository.GetAll()));
        }

        //
        // POST: /Projeto/CreateTarefa
        [HttpPost]
        public void CreateTarefa(TarefaFormViewModel tarefaVM)
        {

            var projeto = _projetoRepository.GetById(tarefaVM.Id);

            var tarefa = new Tarefa();
            tarefaVM.ToTarefa(tarefa);

            tarefa.AdicionarColaborador(_colaboradorRepository.GetById(tarefaVM.ResponsavelId));
            tarefa.CreatedAt = DateTime.Today;

            projeto.Tarefas.Add(tarefa);

            _projetoRepository.Edit(projeto);

        }

        
        
        public void ConcluirTarefa(Guid id, Guid projetoId)
        {
            var projeto = _projetoRepository.GetById(projetoId);

            projeto.Tarefas[id].DataFinalizacao = DateTime.Today;

            _projetoRepository.Edit(projeto);
        }

        //
        // GET: /Projeto/Edit/5

        public ActionResult Edit(Guid id)
        {
            var projeto = _projetoRepository.GetById(id);
            return View("Create",new ProjetoFormViewModel(projeto,_colaboradorRepository.GetAll()));
        }

        //
        // POST: /Projeto/Edit/5

        [HttpPost]
        public ActionResult Edit(Guid id, ProjetoFormViewModel projeto)
        {
           
                var projetoSalvar = new Projeto {Id = id};
                projeto.ToProjeto(projetoSalvar);

                projetoSalvar.AdicionarColaborador(_colaboradorRepository.GetById(projeto.ResponsavelId));

                _validator.ValidateAndThrow(projetoSalvar);


                _projetoRepository.Edit(projetoSalvar);

                return RedirectToAction("Index");
           
        }

        //
        //GET: /Projeto/Details/5
        public ActionResult Details(Guid id)
        {
            var projeto = _projetoRepository.GetById(id);

            var vm = new ProjetoDetailsViewModel(projeto);

            return View(vm);
        }

        //
        // GET: /Projeto/Delete/5

        public ActionResult Delete(Guid id)
        {
            _projetoRepository.Delete(id);

            return RedirectToAction("Index");
        }

        

  
  
    }


   
}
