using System.Collections.Generic;
using System.Web.Mvc;
using _2do.Models;

namespace _2do.Controllers
{
    public class TarefasController : Controller
    {
        //
        // GET: /Tarefas/

        public ActionResult Index()
        {
            var models = new List<Tarefa> {new Tarefa {Descricao = "teste"}, new Tarefa {Descricao = "Teste2"}};
            return View(models);
        }

        //
        // GET: /Tarefas/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Tarefas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tarefas/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tarefas/Edit/5

        public ActionResult Edit(int id)
        {

            return View();
        }

        //
        // POST: /Tarefas/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
        // GET: /Tarefas/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Tarefas/Delete/5

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
