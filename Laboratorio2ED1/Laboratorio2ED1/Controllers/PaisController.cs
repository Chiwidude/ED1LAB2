using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laboratorio2ED1.DBContext;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Laboratorio2ED1.Clase;
using ArbolBinarioBu;

namespace Laboratorio2ED1.Controllers
{
    public class PaisController : Controller
    {
        public DefaultConnection db = DefaultConnection.getInstance;

        // GET: Pais
        public ActionResult IndexPais()
        {
            if (db.Orden == 0)
                return View(db.Paises.Infijo());
            else if (db.Orden == 1)
                return View(db.Paises.Prefijo());
            else
                return View(db.Paises.Postfijo());
        }

        public ActionResult OrdenWord(int id, int tipo)
        {
            try
            {
                db.Orden = id;

                if (tipo == 0)
                    return RedirectToAction(nameof(IndexPais));
                else if (tipo == 1)
                    return RedirectToAction(nameof(IndexNumero));
                else
                    return RedirectToAction(nameof(IndexWord));
            }
            catch
            {
                return View();
            }
        }

        // GET: String
        public ActionResult IndexWord()
        {
            if (db.Orden == 0)
                return View(db.Cadenas.Infijo());
            else if (db.Orden == 1)
                return View(db.Cadenas.Prefijo());
            else
                return View(db.Cadenas.Postfijo());
        }

        // GET: Int
        public ActionResult IndexNumero()
        {
            if (db.Orden == 0)
                return View(db.Numeros.Infijo());
            else if (db.Orden == 1)
                return View(db.Numeros.Prefijo());
            else
                return View(db.Numeros.Postfijo());
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
        public ActionResult Delete(string id, string group)
        {
            var aux = new Models.Pais
            {
                Nombre = id,
                grupo = group
            };
            if (aux.Nombre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pais = db.Paises.Encontrar(aux).value;

            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCondirmed(string id, string group)
        {
            var _aux = new Models.Pais
            {
                Nombre = id,
                grupo = group
            };

            db.Paises.Eliminar(db.Paises.Encontrar(_aux).value);

            return RedirectToAction(nameof(IndexPais));
        }
        public ActionResult DeleteString(string id)
        {
            var valor = db.Cadenas.Encontrar(id).value;
          
            
            return View();
        }
        [HttpPost, ActionName(nameof(DeleteString))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteString(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var valor = db.Cadenas.Encontrar(id);
                db.Cadenas.Eliminar(valor.value);
                
                return RedirectToAction(nameof(IndexWord));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteInt(int id)
        {
            var valor = db.Numeros.Encontrar(id).value;
            
            return View(valor);
        }
        [HttpPost,ActionName(nameof(DeleteInt))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInt(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var valor = db.Numeros.Encontrar(id);
                db.Numeros.Eliminar(valor.value);
                return RedirectToAction(nameof(IndexNumero));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UploadInt()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadInt(HttpPostedFileBase file)
        {
            try
            {
                if (!file.FileName.EndsWith(".json"))
                    return View();
                if (file.ContentLength > 0)
                {
                    var json = new Archivo_Json<int>();
                    Nodo<int> raiz = json.Dato(file.InputStream);
                    db.Numeros.root = raiz;
                    return RedirectToAction("IndexNumero");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        [HttpGet]
        public ActionResult UploadPais()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadPais(HttpPostedFileBase file)
        {
            try
            {
                if (!file.FileName.EndsWith(".json"))
                    return View();
                if (file.ContentLength > 0)
                {
                    var json = new Archivo_Json<Models.Pais>();
                    Nodo<Models.Pais> raiz = json.Dato(file.InputStream);
                    db.Paises.root = raiz;
                    return RedirectToAction("IndexPais");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        [HttpGet]
        public ActionResult UploadString()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadStriing(HttpPostedFileBase file)
        {
            try
            {
                if (!file.FileName.EndsWith(".json"))
                    return View();
                if (file.ContentLength > 0)
                {
                    var json = new Archivo_Json<string>();
                    Nodo<string> raiz = json.Dato(file.InputStream);
                    db.Cadenas.root = raiz;
                    return RedirectToAction("IndexWord");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
    }
}
