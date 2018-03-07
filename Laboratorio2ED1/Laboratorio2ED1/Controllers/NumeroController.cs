using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio2ED1.DBContext;
using System.Net;

namespace Laboratorio2ED1.Controllers
{
    public class NumeroController : Controller
    {
        public DefaultConnection<Models.Numero> db = DefaultConnection<Models.Numero>.getInstance;

        // GET: Numero
        public ActionResult Index()
        {
            return View(db.Numeros.Infijo());
        }

        // GET: Numero/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Numero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Numero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Valor")]Models.Numero numero)
        {
            if (ModelState.IsValid)
            {
                db.Numeros.Insertar(numero);

                return RedirectToAction("Index", "Numero");
            }

            return View(numero);
        }

        // GET: Numero/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Numero/Edit/5
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

        // GET: Numero/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Numero _aux = new Models.Numero();
            _aux.Valor = id;

            if (_aux == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.Numero numero = db.Numeros.Encontrar(_aux).value;

            if (numero == null)
            {
                return HttpNotFound();
            }
            return View(numero);
        }

        // POST: Numero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Numero _aux = new Models.Numero();
            _aux.Valor = id;

            db.Numeros.Eliminar(db.Numeros.Encontrar(_aux).value);  
            
            return RedirectToAction("Index");
        }
    }
}
