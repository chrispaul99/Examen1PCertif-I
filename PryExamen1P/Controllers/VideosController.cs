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
    public class VideosController : Controller
    {

        // GET: Videos
        public ActionResult Index()
        {
            ViewBag.title = "Listado de videos";
            return View(VideoBLL.List());
        }

        // GET: Videos/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.title = "Detalle";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = VideoBLL.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            ViewBag.title = "Añadir nuevo video";
            ViewBag.categoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre");
            return View();
        }

        // POST: Videos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idvideo,titulo,fecha_publi,formato,duracion,categoria")] Video video)
        {
            if (ModelState.IsValid)
            {
                VideoBLL.Create(video);
                return RedirectToAction("Index");
            }
            ViewBag.title = "Añadir nuevo video";
            ViewBag.categoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre", video.categoria);
            return View(video);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = VideoBLL.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.title = "Editar video";
            ViewBag.categoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre", video.categoria);
            return View(video);
        }

        // POST: Videos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idvideo,titulo,fecha_publi,formato,duracion,categoria")] Video video)
        {
            if (ModelState.IsValid)
            {
                VideoBLL.Update(video);
                return RedirectToAction("Index");
            }
            ViewBag.title = "Editar video";
            ViewBag.categoria = new SelectList(CategoriaBLL.List(), "idcategoria", "nombre", video.categoria);
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = VideoBLL.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.title = "Eliminar video";
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
