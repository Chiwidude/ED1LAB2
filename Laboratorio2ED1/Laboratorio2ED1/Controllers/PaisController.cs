using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio2ED1.DBContext;
using System.Net;

namespace Laboratorio2ED1.Controllers
{
    public class PaisController : Controller
    {
        public DefaultConnection<Models.Pais> db = DefaultConnection<Models.Pais>.getInstance;

        // GET: Pais
        public ActionResult Index()
        {
            return View(db.Paises.Infijo());
        }

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Nombre,grupo")]Models.Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Paises.Insertar(pais);

                return RedirectToAction("Index","Pais");
            }

            return View(pais);
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pais/Edit/5
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

        // GET: Pais/Delete/5
        public ActionResult Delete(string id, string group)
        {
            Models.Pais _aux = new Models.Pais();
            _aux.Nombre = id;
            _aux.grupo = group;

            if (_aux == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.Pais pais = db.Paises.Encontrar(_aux).value;

            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCondirmed(string id, string group)
        {
            Models.Pais _aux = new Models.Pais();
            _aux.Nombre = id;
            _aux.grupo = group;

            db.Paises.Eliminar(db.Paises.Encontrar(_aux).value);

            return RedirectToAction("Index");
        }

        public ActionResult JsonFile (HttpPostedFileBase jfile)
        {
            return null ;
        }
    }
}
