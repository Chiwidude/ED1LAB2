﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio2ED1.DBContext;

namespace Laboratorio2ED1.Controllers
{
    public class PaisController : Controller
    {
        public DefaultConnection db = DefaultConnection.getInstance;

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

                return RedirectToAction(nameof(IndexPais));
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
        public ActionResult CreateInt( FormCollection numero)
        {
            try
            {

                db.Numeros.Insertar(Convert.ToInt32(numero["valor"]));

                return RedirectToAction(nameof(IndexNumero));
            }
            catch
            {
                return View(numero);
            }
        }
        public ActionResult CreateString()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateString(FormCollection cadena)
        {
            try
            {
                db.Cadenas.Insertar(cadena["Valor"]);
                return RedirectToAction(nameof(IndexWord));
            }
            catch
            {
                return View(cadena["Valor"]);
            }
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
