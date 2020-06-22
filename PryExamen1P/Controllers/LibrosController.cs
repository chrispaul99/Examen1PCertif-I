using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUBiblioteca;
using BEUBiblioteca.Transactions;

namespace PryExamen1P.Controllers
{
    public class LibrosController : Controller
    {
        // GET: Libros
        public ActionResult Index()
        {
            ViewBag.title = "Listado de Libros";
            return View(LibroBLL.List());
        }

        // GET: Libros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.title = "Detalle del Libro";
            return View(libro);
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            ViewBag.title = "Añadir nuevo libro";
            ViewBag.categoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre");
            return View();
        }

        // POST: Libros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLibro,titulo,autores,isbn,fecha_publi,nro_ejem,categoria")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                LibroBLL.Create(libro);
                return RedirectToAction("Index");
            }
            ViewBag.title = "Añadir nuevo libro";
            ViewBag.categoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre", libro.categoria);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.title = "Editar Libro";
            ViewBag.categoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre", libro.categoria);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLibro,titulo,autores,isbn,fecha_publi,nro_ejem,categoria")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                LibroBLL.Update(libro);
                return RedirectToAction("Index");
            }
            ViewBag.title = "Editar Libro";
            ViewBag.categoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre", libro.categoria);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.title = "Eliminar Libro";
            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibroBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
