using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio2ED1.DBContext;

namespace Laboratorio2ED1.Controllers
{
    public class PaisController : Controller
    {
        public DefaultConnection db = new  DefaultConnection();

        // GET: Pais
        public ActionResult IndexPais()
        {
            return View(db.Paises.Infijo());
        }

        // GET: String
        public ActionResult IndexWord()
        {
            return View(db.Cadenas.Infijo());
        }

        // GET: Int
        public ActionResult IndexNumero()
        {
            return View(db.Numeros.Infijo());
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
        public ActionResult CreateInt()
        {
            return View();
        }
        // Post: Int/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInt(int numero)
        {
            if (ModelState.IsValid)
            {
                db.Numeros.Insertar(numero);

                return RedirectToAction("IndexInt", "Pais");
            }
            return View(numero);
        }
        public ActionResult CreateString()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateString(string palabra)
        {
            if(ModelState.IsValid)
            {
                db.Cadenas.Insertar(palabra);
                return RedirectToAction("IndexWord", "Pais");
            }
            return View(palabra);
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pais/Delete/5
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

        public ActionResult JsonFile (HttpPostedFileBase jfile)
        {
            return null ;
        }
    }
}
