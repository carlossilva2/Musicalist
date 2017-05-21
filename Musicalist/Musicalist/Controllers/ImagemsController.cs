using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Musicalist.Models;

namespace Musicalist.Controllers
{
    public class ImagemsController : Controller
    {
        private appDB db = new appDB();

        // GET: Imagems
        public ActionResult Index()
        {
            var imagem = db.Imagem.Include(i => i.Produtos);
            return View(imagem.ToList());
        }

        // GET: Imagems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagem imagem = db.Imagem.Find(id);
            if (imagem == null)
            {
                return HttpNotFound();
            }
            return View(imagem);
        }

        // GET: Imagems/Create
        public ActionResult Create()
        {
            ViewBag.ProdutosFK = new SelectList(db.Produtos, "ProdutosID", "Nome");
            return View();
        }

        // POST: Imagems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImagemID,Image,ProdutosFK")] Imagem imagem)
        {
            if (ModelState.IsValid)
            {
                db.Imagem.Add(imagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutosFK = new SelectList(db.Produtos, "ProdutosID", "Nome", imagem.ProdutosFK);
            return View(imagem);
        }

        // GET: Imagems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagem imagem = db.Imagem.Find(id);
            if (imagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutosFK = new SelectList(db.Produtos, "ProdutosID", "Nome", imagem.ProdutosFK);
            return View(imagem);
        }

        // POST: Imagems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImagemID,Image,ProdutosFK")] Imagem imagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutosFK = new SelectList(db.Produtos, "ProdutosID", "Nome", imagem.ProdutosFK);
            return View(imagem);
        }

        // GET: Imagems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagem imagem = db.Imagem.Find(id);
            if (imagem == null)
            {
                return HttpNotFound();
            }
            return View(imagem);
        }

        // POST: Imagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagem imagem = db.Imagem.Find(id);
            db.Imagem.Remove(imagem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
