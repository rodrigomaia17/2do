using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2do.Data.Factory;
using _2do.Data.Interfaces;
using _2do.Models;

namespace _2do.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepository _repository;

        public ColaboradorController(IRepositoryFactory repository)
        {
            _repository = repository.getColaboradorRepository();
        }

        public ActionResult Index()
        {
            var colaboradores = _repository.GetAll();
            return View(colaboradores);
        }

        //
        // GET: /Colaborador/Details/5

        public ActionResult Details(Guid id)
        {
            var colaborador = _repository.GetById(id);
            return View(colaborador);
        }

        //
        // GET: /Colaborador/Create

        public ActionResult Create()
        {
            return View(new Colaborador());
        }

        //
        // POST: /Colaborador/Create

        [HttpPost]
        public ActionResult Create(Colaborador colaborador)
        {
            try
            {
                _repository.Insert(colaborador);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Colaborador/Edit/5

        public ActionResult Edit(Guid id)
        {
            var colaborador = _repository.GetById(id);
            return View("Create", colaborador);
        }

        //
        // POST: /Colaborador/Edit/5

        [HttpPost]
        public ActionResult Edit(Guid id, Colaborador colaborador)
        {
            try
            {
                colaborador.Id = id;
                _repository.Edit(colaborador);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Colaborador/Delete/5

        public ActionResult Delete(Guid id)
        {
            _repository.Delete(id);

            return RedirectToAction("Index");
        }



    }
}
