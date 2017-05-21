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
    public class ComprasProdutosController : Controller
    {
        private appDB db = new appDB();

        // GET: ComprasProdutos
        public ActionResult Index()
        {
            var comprasProdutos = db.ComprasProdutos.Include(c => c.C).Include(c => c.P);
            return View(comprasProdutos.ToList());
        }

        // GET: ComprasProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprasProdutos comprasProdutos = db.ComprasProdutos.Find(id);
            if (comprasProdutos == null)
            {
                return HttpNotFound();
            }
            return View(comprasProdutos);
        }

        // GET: ComprasProdutos/Create
        public ActionResult Create()
        {
            ViewBag.ComprasFK = new SelectList(db.Compras, "ComprasID", "Conteudo");
            ViewBag.ProdutosFK = new SelectList(db.Produtos, "ProdutosID", "Nome");
            return View();
        }

        // POST: ComprasProdutos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Preco,NProdutos,ComprasFK,ProdutosFK")] ComprasProdutos comprasProdutos)
        {
            if (ModelState.IsValid)
            {
                db.ComprasProdutos.Add(comprasProdutos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComprasFK = new SelectList(db.Compras, "ComprasID", "Conteudo", comprasProdutos.ComprasFK);
            ViewBag.ProdutosFK = new SelectList(db.Produtos, "ProdutosID", "Nome", comprasProdutos.ProdutosFK);
            return View(comprasProdutos);
        }

        // GET: ComprasProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprasProdutos comprasProdutos = db.ComprasProdutos.Find(id);
            if (comprasProdutos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComprasFK = new SelectList(db.Compras, "ComprasID", "Conteudo", comprasProdutos.ComprasFK);
            ViewBag.ProdutosFK = new SelectList(db.Produtos, "ProdutosID", "Nome", comprasProdutos.ProdutosFK);
            return View(comprasProdutos);
        }

        // POST: ComprasProdutos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Preco,NProdutos,ComprasFK,ProdutosFK")] ComprasProdutos comprasProdutos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comprasProdutos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComprasFK = new SelectList(db.Compras, "ComprasID", "Conteudo", comprasProdutos.ComprasFK);
            ViewBag.ProdutosFK = new SelectList(db.Produtos, "ProdutosID", "Nome", comprasProdutos.ProdutosFK);
            return View(comprasProdutos);
        }

        // GET: ComprasProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprasProdutos comprasProdutos = db.ComprasProdutos.Find(id);
            if (comprasProdutos == null)
            {
                return HttpNotFound();
            }
            return View(comprasProdutos);
        }

        // POST: ComprasProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComprasProdutos comprasProdutos = db.ComprasProdutos.Find(id);
            db.ComprasProdutos.Remove(comprasProdutos);
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
