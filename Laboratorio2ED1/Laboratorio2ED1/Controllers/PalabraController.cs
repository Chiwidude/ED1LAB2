using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio2ED1.DBContext;
using ArbolBinarioBu;
using System.Net;

namespace Laboratorio2ED1.Controllers
{
    public class PalabraController : Controller
    {
        public DefaultConnection<Models.Palabra> db = DefaultConnection<Models.Palabra>.getInstance;

        // GET: Palabra
        public ActionResult Index()
        {
            return View(db.Cadenas.Infijo());
        }

        // GET: Palabra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Palabra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Palabra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Valor")]Models.Palabra palabra)
        {
            if (ModelState.IsValid)
            {
                db.Cadenas.Insertar(palabra);

                return RedirectToAction("Index", "Palabra");
            }

            return View(palabra);
        }

        // GET: Palabra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Palabra/Edit/5
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

        // GET: Palabra/Delete/5
        public ActionResult Delete(string id)
        {
            Models.Palabra _aux = new Models.Palabra();
            _aux.Valor = id;

            if (_aux == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.Palabra palabra = db.Cadenas.Encontrar(_aux).value;

            if (palabra == null)
            {
                return HttpNotFound();
            }
            return View(palabra);
        }

        // POST: Palabra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Models.Palabra _aux = new Models.Palabra();
            _aux.Valor = id;

            db.Cadenas.Eliminar(db.Cadenas.Encontrar(_aux).value);

            return RedirectToAction("Index");
        }
    }
}
