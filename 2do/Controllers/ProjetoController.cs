using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Globalization;
using System.Web.Mvc;
using _2do.Data.Factory;
using _2do.Data.Interfaces;
using _2do.Models;
using _2do.ViewModels;

namespace _2do.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IColaboradorRepository _colaboradorRepository;


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
        // GET: /Projeto/Details/5

        public ActionResult Details(Guid id)
        {
            var projeto = _projetoRepository.GetById(id);
            return View(projeto);
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
            try
            {
                var projeto = new Projeto();
                projetoVM.ToProjeto(projeto);

                projeto.AdicionarColaborador(_colaboradorRepository.GetById(projetoVM.ResponsavelId));

                _projetoRepository.Insert(projeto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        public ActionResult Edit(int id, Projeto projeto)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Projeto/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Projeto/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

   
}
