using System.Web.Mvc;
using MongoDB.Bson;
using _2do.Data;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoRepository _repository;

        public ProjetoController(IProjetoRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Projeto/

        public ActionResult Index()
        {
            var projetos = _repository.GetAll();
            return View(projetos);
        }

        //
        // GET: /Projeto/Details/5

        public ActionResult Details(int id)
        {
            var projeto = _repository.GetById(id);
            return View(projeto);
        }

        //
        // GET: /Projeto/Create

        public ActionResult Create()
        {
            return View(new Projeto());
        }

        //
        // POST: /Projeto/Create

        [HttpPost]
        public ActionResult Create(Projeto projeto)
        {
            try
            {
                _repository.Insert(projeto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Projeto/Edit/5

        public ActionResult Edit(int id)
        {
            var projeto = _repository.GetById(id);
            return View("Create",projeto);
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
